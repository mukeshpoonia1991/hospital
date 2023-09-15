using Api.Domain.OTPes;
using ApiWeb.Webapi.Dto.Logins;
using Apiwork.Data.Data;
using Apiwork.domain.Employees;
using Apiwork.domain.EmployesLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWeb.Webapi.Controllers
{


    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public LoginController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("api/penel/checklogin")]
        [HttpPost]

        public async Task<ActionResult> Login(LoginDto login)
        {
            var output = await (from EmployeeLogin in _dataContext.employeeLogins
                                join Employee in _dataContext.employees on EmployeeLogin.EmployeeId equals Employee.Id
                                join emptype in _dataContext.employeeTypes on Employee.EmployeeTypeId equals emptype.Id
                                where EmployeeLogin.Code == login.Code && EmployeeLogin.Password == login.Password
                                select new LoginCompletedDetails    
                                {
                                    Id = Employee.Id,
                                    Name = Employee.FirstName + "" + Employee.LastName,
                                    Email = Employee.EmailId,
                                    Role = emptype.Name,
                                }).FirstOrDefaultAsync();
            if (output != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Id",output.Id.ToString()),
                    new Claim (ClaimTypes.Name,output.Name),
                    new Claim (ClaimTypes.Email,output .Email),
                    new Claim (ClaimTypes.Role,output.Role)
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: claims,

                    expires: DateTime.Now.AddHours(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });

            }

            else
            {
                return Unauthorized();

            }


        }
        [Route("Api/penel/otpGenerate")]
        [HttpPost]
        public async Task<ActionResult> Generate(long mobileNo)
        {
            var checkNumber = await _dataContext.employees.Where(x => x.MobileNo == mobileNo).FirstOrDefaultAsync();
            if (checkNumber == null)
            {
                return BadRequest("Number Does not Exists!!");
            }
            else
            {
                int _min = 100000;
                int _max = 999999;
                Random rdm = new Random();
                var code = rdm.Next(_min, _max);

                var expirationTime = DateTime.Now.AddMinutes(2);


                OTP otp = new OTP()
                {
                    CODE = code,
                    ExpirationTime = expirationTime,
                    EmployessID = checkNumber.Id
                };
                var exists = await _dataContext.OTPs.Where(x => x.EmployessID == otp.EmployessID).FirstOrDefaultAsync();
                if (exists == null)
                {

                    _dataContext.OTPs.Add(otp);
                    await _dataContext.SaveChangesAsync();
                    return Ok(code);

                }
                else
                {
                    exists.CODE = code;
                    exists.ExpirationTime = expirationTime;
                    _dataContext.OTPs.Update(exists);

                    await _dataContext.SaveChangesAsync();
                    return Ok(code);
                }
            }


        }



        [Route("Api/penel/otp/verify")]
        [HttpPost]
        public async Task<ActionResult> NewPassword(passwordDto input)
        {
            var data = await _dataContext.OTPs.Where(x => x.EmployessID == input.EmployessID).FirstOrDefaultAsync();
            if (data == null)
            {
                return BadRequest("otp is wrong");
            }
            else
            {
                var gettime = DateTime.Now;
                if (data.CODE != input.Otp || data.ExpirationTime < gettime)
                {
                    return BadRequest("otp is worng");
                }
                else
                {
                    var resp = await _dataContext.employeeLogins.Where(x => x.EmployeeId == input.EmployessID).FirstOrDefaultAsync();
                    if (resp != null)
                    {
                        resp.Password = input.Password;
                        _dataContext.employeeLogins.Update(resp);
                        await _dataContext.SaveChangesAsync();
                        return Ok(resp);
                    }
                    else
                    {
                        return BadRequest("Some Error Occured!!");

                    }

                }


            }
        }
    }
}

