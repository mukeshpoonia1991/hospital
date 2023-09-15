using Apiwork.Data.Data;
using Apiwork.domain.PatientDocuments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDocementController : ControllerBase
    {
        private DataContext _dataContext;
        public PatientDocementController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.patientDocuments.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetByid(int id)
        {
            var data = await _dataContext.patientDocuments.FindAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task <IActionResult>Create(PatientDocument input)
        {
            var data= await _dataContext.patientDocuments.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(data);
           
            
        }
        [HttpPut("id")]

        public async Task<IActionResult>Update(PatientDocument input,int id)
        {
            var data = await _dataContext.patientDocuments.FindAsync(id);
            data.Id = input.Id;
            data.PatientID = input.PatientID;
            data.DocumentID=input.DocumentID;
            _dataContext.patientDocuments.Update(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpDelete("id")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.patientDocuments.FindAsync(id);
            _dataContext.patientDocuments.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
    }
}
