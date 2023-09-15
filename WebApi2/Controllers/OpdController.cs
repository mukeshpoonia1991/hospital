using Api.Domain.Hospitales;
using ApiWeb.Webapi.Dto.OPDs;
using Apiwork.Data.Data;
using Apiwork.domain.Hospitales;
using Apiwork.domain.OPDs;
using Apiwork.domain.Patients;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpdController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OpdController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [Route("api/panel/Opd")]

        [HttpGet]
        public async Task<ActionResult<List<OPDDTO>>> Get()
        {
            var data = await (from p in _dataContext.patients
                              join o in _dataContext.opds on p.Id equals o.PatientId
                              select new OPDDTO()
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Gender = p.Gender,
                                  DOB = p.DOB,
                                  MobileNo = p.MobileNo,
                                  MiritalStatus = p.MiritalStatus,
                                  Email = p.Email,
                                  Address = p.Address,
                                  City = p.City,
                                  Date = o.Date,
                                  ValiduptoDate = o.ValiduptoDate,
                                  InvoiceNumber = o.InvoiceNumber,
                                  DayNumber = o.DayNumber,
                                  DoctorId = o.DoctorId,
                                  OpetorId = o.OpetorId,
                                  Description = o.Description,
                                  Weight = o.Weight,
                                  BP = o.BP,
                                  Temp = o.Temp,
                                  Amount = o.Amount,
                                  Discount = o.Discount,
                                  ServiceId = o.ServiceId,



                              }

                             ).ToListAsync();

            var list = _mapper.Map<List<OPDDTO>>(data);
            return list;


        }


        [Route("api/panel/Opd/{id}")]

        [HttpGet]
        public async Task<ActionResult<OPDDTO>> Get( int id)
        {
            var data = await (from p in _dataContext.patients
                              join o in _dataContext.opds on p.Id equals o.PatientId
                              where o.Id == id
                              select new OPDDTO()
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Gender = p.Gender,
                                  DOB = p.DOB,
                                  MobileNo = p.MobileNo,
                                  MiritalStatus = p.MiritalStatus,
                                  Email = p.Email,
                                  Address = p.Address,
                                  City = p.City,
                                  Date = o.Date,
                                  ValiduptoDate = o.ValiduptoDate,
                                  InvoiceNumber = o.InvoiceNumber,
                                  DayNumber = o.DayNumber,
                                  DoctorId = o.DoctorId,
                                  OpetorId = o.OpetorId,
                                  Description = o.Description,
                                  Weight = o.Weight,
                                  BP = o.BP,
                                  Temp = o.Temp,
                                  Amount = o.Amount,
                                  Discount = o.Discount,
                                  ServiceId = o.ServiceId,



                              }

                             ).FirstOrDefaultAsync();

            var list = _mapper.Map<OPDDTO>(data);
            return (list);


        }

        [Route("api/panel/Opd")]
        [HttpPost]

        public async Task<ActionResult<OPDDTO>> Post(CreateOpdDto input)
        {
            Patient patient = _mapper.Map<Patient>(input);
            _dataContext.patients.Add(patient);

            Opd opd = _mapper.Map<Opd>(input);
            _dataContext.opds.Add(opd);

            opd.patient = patient;
            await _dataContext.SaveChangesAsync();
            _mapper.Map<OPDDTO>(opd);

            return Ok();   

        }


        [Route("api/panel/patient/{id}")]
        [HttpPut]
        public async Task<ActionResult<OPDDTO>>Put(UpdatePatientDto input, int id)
            {
            Patient patient = await _dataContext.patients.FindAsync(id);
            patient.Name = input.Name;
            patient.Gender = input.Gender;
            patient.DOB=input.DOB;
            patient.MiritalStatus=input.MiritalStatus;
            patient.MobileNo = input.MobileNo;
            patient.Email = input.Email;
            patient.Address = input.Address;
            patient.City = input.City;
            _dataContext.patients.Update(patient);
            await _dataContext.SaveChangesAsync();

            var output= _mapper.Map<OPDDTO>(patient);
            return Ok(output);
        }
        [Route("api/panel/Opd/{id}")]
        [HttpPut]

        public async Task <ActionResult<OPDDTO>>Put(UpdateOpdDto input, int id)
        {
            Opd opd = await _dataContext.opds.FindAsync(id);
            opd.Date = input.Date;
            opd.ValiduptoDate=input.ValiduptoDate;
            opd.InvoiceNumber=input.InvoiceNumber;
            opd.DayNumber=input.DayNumber;
            opd.DoctorId=input.DoctorId;
            opd.OpetorId = input.OpetorId;
            opd.Description = input.Description;
            opd.Weight=input.Weight;
            opd.BP = input.BP;
           opd.Temp=input.Temp;
            opd.Amount = input.Amount;
            opd.Discount=input.Discount;
            opd.ServiceId = input.ServiceId;

            _dataContext.opds.Update(opd);

            await _dataContext.SaveChangesAsync();

            var output= _mapper.Map<OPDDTO>(opd);
            return Ok(output);
        }

        [Route("api/panel/Opd/{id}")]

        [HttpDelete]

        public async void Delete(int id)
        {
            Patient patient = await _dataContext.patients.FindAsync(id);
            Opd opd= await _dataContext.opds.FindAsync(id);
            if (opd == null)
            {
                BadRequest("");
            }
            _dataContext.patients.Remove(patient);
            _dataContext.opds.Remove(opd);
            await _dataContext.SaveChangesAsync();
        }
    }


}
