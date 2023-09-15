using ApiWeb.Webapi.Dto.Services.Types;
using Apiwork.Data.Data;
using Apiwork.domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {

        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;
        public ServiceTypeController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("api/panel/service/type")]
        public async Task<ActionResult<List<ServiceTypeDto>>> GetList()
        {
            var output = await _dataContext.serviceTypes.ToListAsync();
            var list = _mapper.Map<List<ServiceTypeDto>>(output);
            return Ok(list);
        }
        [HttpGet]
        [Route("api/panel/service/type/{id}")]

        public async Task<ActionResult<ServiceTypeDto>> Get(int id)
        {
            var data = await _dataContext.serviceTypes.FindAsync(id);

            var output = _mapper.Map<ServiceTypeDto>(data);
            return Ok(output);
        }

        [HttpPost]
        [Route("api/panel/service/type")]
     
        public async Task <ActionResult<ServiceTypeDto>>Post(CreateServiceTypeDto input)
        {
            ServiceType service =_mapper.Map<ServiceType>(input);
            _dataContext.serviceTypes.Add(service);

            await _dataContext.SaveChangesAsync();
             var output= _mapper.Map<ServiceTypeDto>(service);
            return output;

           
        }

        [Route("api/panel/service/type/{id}")]
        [HttpPut]

        public async Task <ActionResult<ServiceTypeDto>> Update(UpdateServiceTypeDto input, int id)
        {
            ServiceType service =await _dataContext.serviceTypes.FindAsync(id);
            if(service == null)
            {
                return BadRequest("Data not find");
            }
            service.Name = input.Name;
            service.IsActived=input.IsActived;
             
            _dataContext.serviceTypes.Update(service);

            await _dataContext.SaveChangesAsync();
            var output = _mapper.Map<ServiceTypeDto>(service);
            return Ok(output);



        }
        [Route("api/panel/service/type/{id}")]
        [HttpDelete]
        public  async Task Delete(int id)
        {
            ServiceType ser = await _dataContext.serviceTypes.FindAsync(id);
            if (ser == null)
            {
                BadRequest("data is not find");
            }

            _dataContext.serviceTypes.Remove(ser);
           await _dataContext.SaveChangesAsync();
            
        }
    }
}
