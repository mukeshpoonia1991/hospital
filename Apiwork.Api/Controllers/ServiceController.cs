using Apiwork.Data.Data;
using Apiwork.Data.Migrations;
using Apiwork.domain.Services;
using Apiworks.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private DataContext _dataContext;

        public ServiceController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await _dataContext.services.ToListAsync();
            return Ok(data);
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetByid(int id)
        {
            var data=await _dataContext.services.FindAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult>Create(ServiceDto input)
        {
            Service servicedto = new Service();
            
                servicedto.Id = input.Id;
                servicedto.ServiceTypeId = input.ServiceTypeId;
                servicedto.Name=input.Name;
                servicedto.Amount = input.Amount;
                servicedto.discountable = input.discountable;
                servicedto.Creatorid = input.Creatorid;
                servicedto.createdDate = input.createdDate;
                servicedto.ValidDay = input.ValidDay;
                servicedto.Hospitalid = input.Hospitalid;
                await _dataContext.services.AddAsync(servicedto);
                _dataContext.SaveChanges();
                return Ok(servicedto);
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(Service input,int id)
        {
            var data = await _dataContext.services.FindAsync(id);

            data.Id = input.Id;
            data.ServiceTypeId = input.ServiceTypeId;
            data.Name = input.Name;
            data.Amount = input.Amount;
            data.createdDate = input.createdDate;
            data.Creatorid = input.Creatorid;
            data.Hospitalid = input.Hospitalid;
            data.ValidDay = input.ValidDay;
            data.discountable = input.discountable;
            _dataContext.services.Update(input);
            _dataContext.SaveChanges();
            return Ok(data);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _dataContext.services.FindAsync(id);
            _dataContext.services.Remove(data);
            return Ok(data);
        }
    }
}
