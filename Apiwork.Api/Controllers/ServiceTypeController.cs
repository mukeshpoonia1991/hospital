using Apiwork.Data.Data;
using Apiwork.domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private DataContext _dataContext;
        public ServiceTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }  
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.serviceTypes.ToListAsync();
           return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult>GetByid(int id)
        {
            var data = await _dataContext.serviceTypes.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(ServiceType input)
        {
            var data = await _dataContext.serviceTypes.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(ServiceType input,int id)
        {
            var data = await _dataContext.serviceTypes.FindAsync(id);
            data.Id = input.Id;
            data.Name = input.Name;
            _dataContext.serviceTypes.Update(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.serviceTypes.FindAsync(id);
            _dataContext.serviceTypes.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
    }
}
