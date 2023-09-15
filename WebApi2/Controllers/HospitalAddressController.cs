using Api.Domain.Hospitales;
using ApiWeb.Webapi.Dto.Hospitals;
using Apiwork.Data.Data;
using Apiwork.domain.Docuement;
using Apiwork.domain.Hospitales;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{

    [ApiController]
    public class HospitalAddressController : ControllerBase
    {
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;



        public HospitalAddressController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [Route("api/panel/Hosptal")]
        [HttpGet]
        public async Task<ActionResult<List<HospitalDto>>> Get()
        {
            var output = await (from hos in _dataContext.hospitalAddresses
                                join ha in _dataContext.hospitals on hos.HospitalId equals ha.Id
                                select new HospitalDto()
                                {
                                    Id = hos.Id,
                                    Name = ha.Name,
                                    Logo = ha.Logo,
                                    RegistrationNumber = ha.ResgisterNumber,
                                    ContactNumber = ha.ContactNumber,
                                    Website = ha.WebSite,
                                    MailId = ha.MailId,

                                    Address1 = hos.Address1,
                                    Address2 = hos.Address2,
                                    City = hos.city,
                                    State = hos.State,
                                    PinCode = hos.pincode,

                                }
                               ).ToListAsync();
            var list = _mapper.Map<List<HospitalDto>>(output);
            return list;


        }


        [Route("api/panel/Hosptal/{id}")]
        [HttpGet]
        public async Task<ActionResult<HospitalDto>> Get(int id)
        {
            var output = await (from hos in _dataContext.hospitalAddresses
                                join ha in _dataContext.hospitals on hos.HospitalId equals ha.Id
                                where hos.Id == id
                                select new HospitalDto()
                                {

                                    Id= hos.Id,
                                    Name = ha.Name,
                                    Logo = ha.Logo,
                                    RegistrationNumber = ha.ResgisterNumber,
                                    ContactNumber = ha.ContactNumber,
                                    Website = ha.WebSite,
                                    MailId = ha.MailId,

                                    Address1 = hos.Address1,
                                    Address2 = hos.Address2,
                                    City = hos.city,
                                    State = hos.State,
                                    PinCode = hos.pincode,

                                }
                               ).FirstOrDefaultAsync();
            var list = _mapper.Map<HospitalDto>(output);
            return(list);

        }

        [Route("api/panel/Hosptal")]
        [HttpPost]

        public async Task<ActionResult<HospitalDto>> Post(CreateUpdateHospitalDto input)
        {
            Hospital hospital = _mapper.Map<Hospital>(input);
            _dataContext.hospitals.Add(hospital);
         

            var output = _mapper.Map<HospitalDto>(hospital);

            HospitalAddress hospitalAddress = _mapper.Map<HospitalAddress>(input);
            _dataContext.hospitalAddresses.Add(hospitalAddress);
            hospitalAddress.hospital = hospital;
            await _dataContext.SaveChangesAsync();

            _mapper.Map<HospitalDto>(hospitalAddress);

            return Ok();
        }
        [Route("api/panel/Hosptal/{id}")]

        [HttpPut]

        public async Task<ActionResult<HospitalDto>> Put(UpdateHospitalDto input, int id)
        {
            Hospital hospital = await _dataContext.hospitals.FindAsync(id);
            hospital.Name = input.Name;
            hospital.Logo = input.Logo;
            hospital.ResgisterNumber = input.ResgisterNumber;
            hospital.ContactNumber = input.ContactNumber;
            hospital.WebSite = input.WebSite;
            hospital.MailId = input.MailId;

            _dataContext.hospitals.Update(hospital);
            await _dataContext.SaveChangesAsync();
            var output = _mapper.Map<HospitalDto>(hospital);
            return Ok(output);
          
        }
        [Route("api/panel/HosptalAddress/{id}")]
        [HttpPut]
        public async Task<ActionResult<HospitalDto>>Put(UpdateHospitalAddressDto input, int id)
            {
            HospitalAddress hospitalAddress = await _dataContext.hospitalAddresses.FindAsync(id);
            hospitalAddress.Address1 = input.Address1;
            hospitalAddress.Address2 = input.Address2;
            hospitalAddress.city = input.city;
            hospitalAddress.pincode = input.pincode;
            hospitalAddress.State = input.State;
            _dataContext.hospitalAddresses.Update(hospitalAddress);
            await _dataContext.SaveChangesAsync();
            var output =  _mapper.Map<HospitalDto>(hospitalAddress);
            return Ok(hospitalAddress);


          }


        [Route("api/panel/Hosptal/{id}")]
        [HttpDelete]

        public async Task Delete(int id)
        {
            HospitalAddress hospitalAddress = await _dataContext.hospitalAddresses.FindAsync(id);
            Hospital hospital = await _dataContext.hospitals.FindAsync(id);

            if (hospitalAddress == null)    
            {
                BadRequest("not delete");
            }
            _dataContext.hospitalAddresses.Remove(hospitalAddress);
            _dataContext.hospitals.Remove(hospital);
        
           

            await _dataContext.SaveChangesAsync();
        }



    }
}
