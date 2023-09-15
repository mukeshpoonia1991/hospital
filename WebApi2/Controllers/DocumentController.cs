using ApiWeb.Webapi.Dto.Documents;
using Apiwork.Data.Data;
using Apiwork.domain.Docuement;
using Apiwork.domain.Documents;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        

        public DocumentController(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

       /* public IActionResult uploadImage()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult uploadImage(CreateUpdateDocumentDto input)
        {
            return Ok();
        }*/


        [Route("api/penel/document")]
        [HttpGet]
        public async Task<ActionResult<List<DocumentDto>>> Get()
        {
            var data = await _dataContext.documents.ToListAsync();
            var list =   _mapper.Map<List<DocumentDto>>(data);
            return list;
        }

        [Route("api/penel/document/{id}")]
        [HttpGet]
        public async Task<ActionResult<DocumentDto>> Get(int id)
        {
            var data = await _dataContext.documents.FindAsync();
            var output = _mapper.Map<DocumentDto>(data);
            return output;
        }

        [Route("api/penel/document")]
        [HttpPost]
        public async Task<ActionResult<DocumentDto>> Post(CreateUpdateDocumentDto input)
        {
            Document document = _mapper.Map<Document>(input);
            _dataContext.documents.Add(document);
            await _dataContext.SaveChangesAsync();
            var output = _mapper.Map<DocumentDto>(document);
            return output;


        }
        [Route("api/penel/document")]
        [HttpPut]

        public async Task<ActionResult<DocumentDto>> Put(CreateUpdateDocumentDto input, int id)
        {
            Document document = await _dataContext.documents.FindAsync(input);
            if (document == null)
            {
                BadRequest("data is not found");
            }
            document.DocuementTypeID = input.DocuementTypeID;
            document.Url = input.Url;

            _dataContext.documents.Update(document);
            await _dataContext.SaveChangesAsync();
/*
            var output =  _mapper.Map<DocumentDto>(document);*/
            return Ok();

        }
        [Route("api/panel/document/{id}")]

        [HttpDelete]
        public async Task delete(int id)
        {
            Document document = await _dataContext.documents.FindAsync(id);
            if (document == null)
            {
                BadRequest("not delete");
            }
            _dataContext.documents.Remove(document);
            await _dataContext.SaveChangesAsync();
        }

    }
}
