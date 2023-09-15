using Apiwork.Data.Data;
using Apiwork.domain.Depatemants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepatementController : ControllerBase
    {
        private DataContext _dataContext;
        public DepatementController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var data = await _dataContext.depatemants.FindAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task <IActionResult> GetList()
        {
            var data = await _dataContext.depatemants.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task <IActionResult> Create(Depatemant input)
        {
            var data= await _dataContext.depatemants.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);    
        }
        [HttpPut("{id}")]

        public async Task<IActionResult>update(Depatemant input,int id)
        {
            var data = await _dataContext.depatemants.FindAsync(id);
            data.Id = input.Id;
            data.DepatemantName = input.DepatemantName;
            _dataContext.depatemants.Update(input);
            _dataContext.SaveChanges();
            return Ok(data);

        }
        [HttpDelete("{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            var data = await _dataContext.depatemants.FindAsync(id);
            _dataContext.depatemants.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
    }
}
