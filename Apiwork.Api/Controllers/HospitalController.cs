using Apiwork.Data.Data;
using Apiwork.domain.Hospitales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiwork.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private DataContext _dataContext;
        public HospitalController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Getbyid(int id)
        {
            var data=await _dataContext.hospitals.FindAsync(id);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.hospitals.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Hospital input)
        {
            var data= await _dataContext.hospitals.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(Hospital input,int id)
        {
            var data = await _dataContext.hospitals.FindAsync(id);
                if (data != null)
            {
                data.name = input.name;
                data.Logo = input.Logo;
                data.ResgisterNumber=input.ResgisterNumber;
                _dataContext.hospitals.Update(input);
                _dataContext.SaveChanges();
                return Ok(data);

            }
            else 
            {

            }
            {
                return BadRequest("if not update please check");
            }

           
           
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.hospitals.FindAsync(id);
            if(data != null)
            {
                _dataContext.hospitals.Remove(data);
                _dataContext.SaveChanges();
                return Ok(data);
            }
            else
            {
                return BadRequest("Delete is not working ....");
            }
        }
    }
}
