using Apiwork.Data.Data;
using Apiwork.domain.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private DataContext _dataContext;
         
        public PatientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.patients.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var data = await _dataContext.patients.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Patient input)
        {
            var data = await _dataContext.patients.AddAsync(input); 
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult>Update(Patient input,int id)
        {
            var data = await _dataContext.patients.FindAsync(id);
          

            data.Name = input.Name;
            data.Gender = input.Gender;
            data.MiritalStatus = input.MiritalStatus;
            data.MobileNo = input.MobileNo;
            data.Email = input.Email;
            data.Address = input.Address;
            data.City = input.City;
            _dataContext.patients.Update(data);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _dataContext.patients.FindAsync(id);
            _dataContext.patients.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }      
    }
}
