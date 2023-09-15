using ApiWeb.Webapi.Dto.Documents.Types;
using Apiwork.Data.Data;
using Apiwork.domain.Docuement;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public DocumentTypeController(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/panel/document/type")]

        public async Task <ActionResult<List<DocumenttypeDto>>>GetList()
        {
            var output = await _dataContext.documentTypes.ToListAsync();
            var list= _mapper.Map<List<DocumenttypeDto>>(output);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/panel/document/type/{id}")]

        public async Task< ActionResult<DocumenttypeDto>> Get(int id)
        {
           var data=await _dataContext.documentTypes.FindAsync(id);

            var output = _mapper.Map<DocumenttypeDto>(data);
            return Ok(output);


        }
        [HttpPost]
        [Route("api/panel/document/type")]

        public async Task <ActionResult<DocumenttypeDto>>Post(CreateUpdateDocumentTypeDto input)
        {
            DocumentType documentType =  _mapper.Map<DocumentType>(input);
            _dataContext.documentTypes.Add(documentType);
            await _dataContext.SaveChangesAsync();
            var output = _mapper.Map<DocumenttypeDto>(documentType);
            return Ok(output);

        }
        [HttpPut]
        [Route("api/panel/document/type")]

        public async Task <ActionResult<DocumenttypeDto>> Put(CreateUpdateDocumentTypeDto input, int id)
        {
            DocumentType document = await _dataContext.documentTypes.FindAsync(id);

            if (document == null)
            {
                BadRequest("data not found");
            }
            document.Name = input.Name;
         

            _dataContext.documentTypes.Update(document);
            await _dataContext.SaveChangesAsync();

            var output = _mapper.Map<DocumenttypeDto>(document);
            return output;



        }
        [Route("api/panel/document/type")]

        [HttpDelete]
        public async Task  delete( int id)
        {
            DocumentType documentType = await _dataContext.documentTypes.FindAsync(id);
            if (documentType == null)
            {
                 BadRequest("not delete");
            }
            _dataContext.documentTypes.Remove(documentType);
            await _dataContext.SaveChangesAsync();
        }
    }
}
