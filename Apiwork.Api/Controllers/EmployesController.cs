using Apiwork.Data.Data;
using Apiwork.domain.Employees;
using Apiwork.domain.EmployesLogin;
using Apiworks.Api.Dto.EmployessDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private DataContext _DataContext;
        public EmployesController(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetList()
        {
            var data = await (from e in _DataContext.employes
                              join et in _DataContext.employessTypes on e.EmployeeTypeid equals et.Id
                              join el in _DataContext.employesLogins on e.id equals el.EmployesId
                    

                             
                              
                              select new EmployessListDto
                              {
                                  id=e.id,
                                  FirstName=e.FirstName,
                                  MeddleName=e.MeddleName,
                                  LastName =e.LastName,
                                  MobileNo=e.MobileNo,
                                  AlterNetMobileNo=e.AlterNetMobileNo,
                                  DataOfBirth=e.DataOfBirth,
                                  DataofJoin=e.DataofJoin,
                                  Gender=e.Gender,
                                  EmployeeTypeid=e.EmployeeTypeid,
                                  LoginCode = el.Code,
                                 
                                  Createddate =e.Createddate,
                                  Creatorid=e.Creatorid,
                                  EmailId=e.EmailId,
                                  

                              }).ToListAsync();

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var data = await _DataContext.employes.FindAsync(id);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult>Create(CreateUpdateEmployesDto input)
        {
            Employe em = new Employe();
            {
                em.id = input.id;
                em.FirstName = input.FirstName;
                em.LastName = input.LastName;
                em.MobileNo = input.MobileNo;
                em.AlterNetMobileNo = input.AlterNetMobileNo;
                em.MeddleName = input.MeddleName;
                em.Createddate = input.Createddate;
                em.Creatorid = input.Creatorid;
                em.EmailId = input.EmailId;
                em.HospitalId = input.HospitalId;
                em.Gender = input.Gender;
                em.DataOfBirth = input.DataOfBirth;
                em.DataofJoin = input.dataofJoin;
                em.EmployeeTypeid = input.EmployesTypeID;
                await _DataContext.employes.AddAsync(em);
                _DataContext.SaveChanges();

            }
            EmployesLogin sa = new EmployesLogin();
            {
                sa.EmployesId = em.id;
                sa.password = input.Password;
                sa.Code = input.LoginCode;
                await _DataContext.employesLogins.AddAsync(sa);
                _DataContext.SaveChanges();
            }
            return Ok();


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CreateUpdateEmployesDto input, int id)

        {
            Employe em = new Employe();
            {
                em.id = input.id;
                em.FirstName = input.FirstName;
                em.LastName = input.LastName;
                em.MobileNo = input.MobileNo;
                em.AlterNetMobileNo = input.AlterNetMobileNo;
                em.MeddleName = input.MeddleName;
                em.Createddate = input.Createddate;
                em.Creatorid = input.Creatorid;
                em.EmailId = input.EmailId;
                em.HospitalId = input.HospitalId;
                em.Gender = input.Gender;
                em.DataOfBirth = input.DataOfBirth;
                em.DataofJoin = input.dataofJoin;
                em.EmployeeTypeid = input.EmployesTypeID;
                _DataContext.employes.Update(em);
                _DataContext.SaveChanges();

            }
            EmployesLogin el= new EmployesLogin();
            {
                el.EmployesId = em.id;
                el.password = input.Password;
                el.Code = input.LoginCode;
                _DataContext.employesLogins.Update(el);
                _DataContext.SaveChanges();
            }
            return Ok();

        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _DataContext.employes.FindAsync(id);
            _DataContext.employes.Remove(data);
            _DataContext.SaveChanges();
            return Ok(data);
        }
    }
}
