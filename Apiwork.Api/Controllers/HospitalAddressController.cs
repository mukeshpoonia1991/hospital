using Apiwork.Data.Data;
using Apiwork.domain.HospitalAddress;
using Apiwork.domain.Hospitales;
using Apiworks.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiwork.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HospitalAddressController : ControllerBase
    {
        private DataContext _dataContext;
        public HospitalAddressController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var data = await (from ha in _dataContext.hospitalAddres
                              join h in _dataContext.hospitals on ha.hospitalId equals h.id
                              select new HospitalAddressDto
                              {
                                id = ha.id,
                                name=h.name,
                                Logo=h.Logo,
                                ResgisterNumber=h.ResgisterNumber,
                                Address1 = ha.Address1,
                                Address2 = ha.Address2,
                                ContactNumber=ha.ContactNumber,
                                MailId = ha.MailId,
                                city = ha.city,
                                pincode = ha.pincode,
                                latitude = ha.latitude,
                                Logitude = ha.Logitude,
                                WebSide=ha.WebSide,
           
                              }
                           ).ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Getbyid(int id)
        {
            var data = await _dataContext.hospitalAddres.FindAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult>Create(HospitalAddressDto input)
        {
            HospitalAddres tr = new HospitalAddres();
            {
                tr.hospitalId = input.hospitalId;
                tr.ContactNumber = input.ContactNumber;
                tr.Address1 = input.Address1;
                tr.Address2 = input.Address2;
                tr.MailId = input.MailId;
                tr.WebSide = input.WebSide;
                tr.city = input.city;
                tr.pincode = input.pincode;
                tr.latitude = input.latitude;
                tr.Logitude = input.Logitude;
                await _dataContext.hospitalAddres.AddAsync(tr);
                _dataContext.SaveChanges();

            }
            Hospital ha = new Hospital();
            {
                ha.Logo=input.Logo;
                ha.name = input.name;
                ha.ResgisterNumber = input.ResgisterNumber;
                _dataContext.hospitals.AddAsync(ha);
                _dataContext.SaveChanges();
            }
         
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(HospitalAddressDto input,int id)
        {
            var data = await _dataContext.hospitalAddres.FindAsync(id);
            HospitalAddres tr = new HospitalAddres();
            {
                tr.hospitalId = input.hospitalId;
                tr.ContactNumber = input.ContactNumber;
                tr.Address1 = input.Address1;
                tr.Address2 = input.Address2;
                tr.MailId = input.MailId;
                tr.WebSide = input.WebSide;
                tr.city = input.city;
                tr.pincode = input.pincode;
                tr.latitude = input.latitude;
                tr.Logitude = input.Logitude;
                _dataContext.hospitalAddres.Update(tr);
                _dataContext.SaveChanges();

            }
            Hospital ha = new Hospital();
            {
                ha.Logo = input.Logo;
                ha.name = input.name;
                ha.ResgisterNumber = input.ResgisterNumber;
                _dataContext.hospitals.Update(ha);
                _dataContext.SaveChanges();
            }

            return Ok();

        }

        [HttpPost("{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            var data = await _dataContext.hospitalAddres.FindAsync(id);
            if (data != null)
            {
                _dataContext.hospitalAddres.Remove(data);
                _dataContext.SaveChanges();
                return Ok(data);
            }
            else
            {
                return BadRequest("delete is not working...");
            }
        }
    }
}
