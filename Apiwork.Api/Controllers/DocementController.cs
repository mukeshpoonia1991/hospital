using Apiwork.Data.Data;
using Apiwork.domain.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Document = Apiwork.domain.Documents.Document;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocementController : ControllerBase
    {
        private DataContext _dataContext;
        public DocementController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.documents.ToListAsync();
            return Ok(data);
        }

        [HttpGet("id")]
        public async Task<IActionResult>GetByid(int id)
        {
            var data= await _dataContext.documents.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Document input)
        {
            var data = await _dataContext.documents.AddAsync(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }
        [HttpPut("id")]
        public async Task <IActionResult>Update(Document input,int id)
        {
            var data = await _dataContext.documents.FindAsync(id);

            data.Id = input.Id;
            data.DocuementTypeID = input.DocuementTypeID;
            data.Url = input.Url;
            _dataContext.documents.Update(input);
            _dataContext.SaveChanges();
            return Ok(input);
        }

        [HttpDelete("id")]

        public async Task <IActionResult>Delete(int id)
        {
            var data = await _dataContext.documents.FindAsync(id);
            _dataContext.documents.Remove(data);
            _dataContext.SaveChanges();
            return Ok(data);
        }
    }
}
