using Apiwork.Data.Data;
using Apiwork.domain.Docuement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocuementTypeController : ControllerBase
    {
        private DataContext _dataContext;
        public DocuementTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]

        public async Task <IActionResult> GetList()
        {
            var data = await _dataContext.docuementTypes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var data =await _dataContext.docuementTypes.FindAsync();
            return Ok(data);
        }
        [HttpPost]
        public async Task <IActionResult> Create(DocuementType input)
        {
            var data = await _dataContext.docuementTypes.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DocuementType input,int id)
        {
            var data = await _dataContext.docuementTypes.FindAsync(id);
            data.Id = input.Id;
                data.Name=input.Name;
            _dataContext.docuementTypes.Update(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            var data = await _dataContext.docuementTypes.FindAsync(id);
            _dataContext.docuementTypes.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);    

        }
    }
}
