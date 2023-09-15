using ApiWeb.Webapi.Dto.Employees.Types;
using Apiwork.Data.Data;
using Apiwork.domain.EmployessTypes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{

    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EmployeeTypeController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [Route("api/panel/employees/Types")]

        [HttpGet]
        public async Task<ActionResult<List<EmployeeTypeDto>>> Get()
        {
            var output = await _dataContext.employeeTypes.ToListAsync();

            var list = _mapper.Map<List<EmployeeTypeDto>>(output);
            return list;
        }

        [Route("api/panel/employees/Types/{id}")]

        [HttpGet]
        public async Task<ActionResult<EmployeeTypeDto>> Get(int id)
        {
            var output = await _dataContext.employeeTypes.FindAsync(id);

            var list = _mapper.Map<EmployeeTypeDto>(output);
            return list;
        }
        [Route("api/panel/employees/Types")]
        [HttpPost]

        public async Task<ActionResult<EmployeeTypeDto>> Create(CreateUpdateEmployeeTypeDto input)
        {
                EmployeeType employee = _mapper.Map <EmployeeType> (input);
            _dataContext.employeeTypes.Add(employee);
            await _dataContext.SaveChangesAsync();

            var output = _mapper.Map<EmployeeTypeDto>(employee);
            return output;
        }
        [Route("api/panel/employees/Types/{id}")]
        [HttpPut]

        public async Task<ActionResult<EmployeeTypeDto>> Put(CreateUpdateEmployeeTypeDto input, int id)
        {
            EmployeeType employeeType = await _dataContext.employeeTypes.FindAsync(id);
            if (employeeType == null)
            {
                BadRequest("data is not Found");
            }
            employeeType.Name = input.Name;
            _dataContext.employeeTypes.Update(employeeType);

            await _dataContext.SaveChangesAsync();

            var output = _mapper.Map<EmployeeTypeDto>(employeeType);
            return output;
        }

        [Route("api/panel/employees/Types/{id}")]

        [HttpDelete]
        public async void Delete(int id)
        {
            EmployeeType employeeType = _dataContext.employeeTypes.Find(id);
            if (employeeType == null)
            {
                BadRequest("");
            }

            _dataContext.employeeTypes.Remove(employeeType);
            await _dataContext.SaveChangesAsync();
        }

    }
}
