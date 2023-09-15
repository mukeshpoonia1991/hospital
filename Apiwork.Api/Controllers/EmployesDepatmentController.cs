using Apiwork.Data.Data;
using Apiwork.domain.EmployesDepatements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployesDepatmentController : ControllerBase
    {
        private DataContext _dataContext;
        public EmployesDepatmentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var data = await _dataContext.employesDepatements.FindAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.employesDepatements.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(EmployesDepatement input)
        {
            var data= await _dataContext.employesDepatements.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpPut("id")]
        public async Task <IActionResult>Update(EmployesDepatement input,int id)
        {
            var data = await _dataContext.employesDepatements.FindAsync(id);
            data.Id = input.Id;
            data.DepatementId = input.DepatementId;
            data.EmployeId=input.EmployeId;

            _dataContext.employesDepatements.Update(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.employesDepatements.FindAsync(id);
            _dataContext.employesDepatements.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
    }
}
