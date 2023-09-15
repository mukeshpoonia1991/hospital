using Api.Domain.Hospitales;
using ApiWeb.Webapi.Dto.Employees;
using Apiwork.Data.Data;
using Apiwork.domain.Employees;
using Apiwork.domain.EmployesLogin;
using Apiwork.domain.Hospitales;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{


    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [Route("api/panel/employees/{id}")]

        [HttpGet,Authorize]
        public async Task<ActionResult<EmployeeDto>> GetByid(int id)
        {
            
            
               

                var output = await (from e in _dataContext.employeeLogins

                                    join ep in _dataContext.employees on e.EmployeeId equals ep.Id
                                    join empt in _dataContext.employeeTypes on ep.EmployeeTypeId equals empt.Id
                                    where ep.Id==id                                    
                                    select new EmployeeDto()
                                    {
                                        Id= ep.Id,
                                        FirstName = ep.FirstName,
                                        MeddleName = ep.MeddleName,
                                        LastName = ep.LastName,
                                        MobileNo = ep.MobileNo,
                                        AlterNetMobileNo = ep.AlterNetMobileNo,
                                        EmailId = ep.EmailId,
                                        Gender = ep.Gender,
                                        EmployeeTypeId = ep.EmployeeTypeId,
                                        DataOfBirth = ep.DataOfBirth,
                                        DataOfJoin = ep.DataOfJoin,
                                        Createddate = ep.Createddate,

                                        Creatorid = ep.Creatorid,
                                        Code = e.Code,
                                        Password = e.Password,

                                    }
                                    ).FirstOrDefaultAsync();
                var list = _mapper.Map<EmployeeDto>(output);
          
                return (list);
            
           



        }






        [Route("api/panel/employees")]

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            try
            {

            var output = await (from ep in _dataContext.employees

                                join e in _dataContext.employeeLogins on ep.Id equals e.EmployeeId
                               // join d in _dataContext.employeeDepartments on e.Id equals d.EmployeId 

                                select new EmployeeDto()
                                {
                                    Id = ep.Id,
                                    FirstName = ep.FirstName,
                                    MeddleName = ep.MeddleName,
                                    LastName = ep.LastName,
                                    MobileNo = ep.MobileNo,
                                    AlterNetMobileNo = ep.AlterNetMobileNo,
                                    EmailId = ep.EmailId,
                                    Gender = ep.Gender,
                                    EmployeeTypeId = ep.EmployeeTypeId,
                                    DataOfBirth = ep.DataOfBirth,
                                    DataOfJoin = ep.DataOfJoin,
                                    Createddate = ep.Createddate,
                                  
                                    Creatorid = ep.Creatorid,
                                    Code = e.Code,
                                    Password ="Hidden!!!",

                                }
                                ).ToListAsync();
            var list = _mapper.Map<List<EmployeeDto>>(output);
            return  list;
            }
            catch
            {
                return BadRequest(" there is an error in your ");
            }
           

        }

            [Route("api/panel/employees")]

        [HttpPost]
        public async Task <ActionResult<EmployeeDto>>Post(CreateEmployeeDto input)
        {
            Employee employee =_mapper.Map<Employee>(input);
            _dataContext.employees.Add(employee);

            EmployeeLogin employeeLogin = _mapper.Map<EmployeeLogin>(input);
            _dataContext.employeeLogins.Add(employeeLogin);
            employeeLogin.employee=employee;
           await _dataContext.SaveChangesAsync();
            return Ok();

        }

        [Route("api/panel/employees/{id}")]
        [HttpPut]

        public async Task<ActionResult<EmployeeDto>> Put(UpdateEmployeeDto input, int id)
        {
            Employee employee = await _dataContext.employees.FindAsync(id);
            employee.FirstName = input.FirstName;
            employee.LastName = input.LastName;
            employee.MeddleName = input.MeddleName;

            employee.EmailId = input.EmailId;
            employee.EmployeeTypeId = input.EmployeeTypeId;
            employee.MobileNo = input.MobileNo;
            employee.AlterNetMobileNo = input.AlterNetMobileNo;
            employee.Createddate = input.Createddate;
            employee.Creatorid = input.Creatorid;
            employee.DataOfBirth = input.DataOfBirth;
            employee.DataOfJoin = input.DataOfJoin;
          
            employee.Gender = input.Gender;

            _dataContext.employees.Update(employee);

            await _dataContext.SaveChangesAsync();

            var output = _mapper.Map<EmployeeDto>(employee);
            return Ok(output);

        }



            [Route("api/panel/employeesLogin/{id}")]
            [HttpPut]
            public async Task<ActionResult<EmployeeDto>> Put(UpdateEmployeeLogInDto input, Int32 id)
            { 

            EmployeeLogin employeeLogin = await _dataContext.employeeLogins.Where(g => g.EmployeeId == id).FirstOrDefaultAsync();
            employeeLogin.Code = input.Code;
            employeeLogin.Password= input.Password;
            _dataContext.employeeLogins.Update(employeeLogin);

            await _dataContext.SaveChangesAsync();
            var output=_mapper.Map<EmployeeDto>(employeeLogin);

            return Ok(output);
           
            


            }

        [Route("api/panel/employee/{id}")]
        [HttpDelete]

        public async Task<ActionResult<EmployeeDto>> Delete(int id)
        {
            Employee employee = await _dataContext.employees.FindAsync(id);
            EmployeeLogin employeeLogin = await _dataContext.employeeLogins.Where(x => x.EmployeeId==id).FirstOrDefaultAsync();

            if (employee == null)
            {
                BadRequest("not delete");
            }
            else if(employeeLogin!=null)
            {
                _dataContext.employeeLogins.Remove(employeeLogin);

            }
            _dataContext.employees.Remove(employee);

            await _dataContext.SaveChangesAsync();
            return Ok("Deleted");

           
            
        }





    }
}
