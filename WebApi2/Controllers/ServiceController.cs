using ApiWeb.Webapi.Dto.Services;
using Apiwork.Data.Data;
using Apiwork.domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ServiceController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [Route("api/panel/service")]
        [HttpGet]
        public async Task<ActionResult<List<ServiceDto>>> Get()
        {
            var output =await _dataContext.services.ToListAsync();
            var list = _mapper.Map<List<ServiceDto>>(output);

            return list;
        }

        [Route("api/panel/service/{id}")]
        [HttpGet]
        public async Task<ActionResult<ServiceDto>> Get(int id)
        {
            var output = await _dataContext.services.FindAsync(id);
            var list = _mapper.Map<ServiceDto>(output);

            return list;
        }
        [Route("api/penel/service")]
        [HttpPost]
        public async Task <ActionResult<ServiceDto>>Post(CreateUpdateServiceDto intput)
        {
            Service service = _mapper.Map<Service>(intput);
            _dataContext.services.Add(service);

            await _dataContext.SaveChangesAsync();
            var output = _mapper.Map<ServiceDto>(service);
            return Ok(output);
        }
        [Route("api/penel/service/{id}")]
        [HttpPut]
        public async Task <ActionResult<ServiceDto>>Put(CreateUpdateServiceDto intput,int id)
        {

            Service service = await _dataContext.services.FindAsync(id);
            service.Name = intput.Name;
            service.Amount = intput.Amount;
            service.Discountable = intput.Discountable;
            service.ServiceTypeId = intput.ServiceTypeId;
            service.Creatorid = intput.Creatorid;
            service.CreatedDate = intput.CreatedDate;
            service.ValidDay = intput.ValidDay;
            service.Hospitalid = intput.Hospitalid;

            _dataContext.services.Update(service);
            await _dataContext.SaveChangesAsync();

            var data = _mapper.Map<ServiceDto>(service);
            return Ok(data);
        }

        [Route("api/penel/service/{Id}")]
        [HttpDelete]
        public  async Task Delete(int Id)
        {
            Service service  = await _dataContext.services.FindAsync(Id);
            if(service==null)
            {
                BadRequest("data is not found");
            }
            _dataContext.services.Remove(service);
           await _dataContext.SaveChangesAsync();


        }
    }
}
