using Apiwork.Data.Data;
using Apiwork.domain.EmployessTypes;
using Apiworks.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesTypeController : ControllerBase
    {
        private DataContext _dataContext;
        public EmployesTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.employessTypes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult>GetByid(int id)
        {
            var data = await _dataContext.employessTypes.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(EmployessType input)
        {
            var data = await _dataContext.employessTypes.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }
        [HttpPut("{id}")]
        public  async Task <IActionResult>Update(EmployessType input,int id)
        {
            var data = await _dataContext.employessTypes.FindAsync(id);

            data.Id = input.Id;
            data.name = input.name;
            _dataContext.employessTypes.Update(input);
            _dataContext.SaveChanges();
            return Ok(data);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.employessTypes.FindAsync(id);
            _dataContext.employessTypes.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }

    }
}
