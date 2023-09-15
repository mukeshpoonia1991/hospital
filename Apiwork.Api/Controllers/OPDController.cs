using Apiwork.Data.Data;
using Apiwork.Data.Migrations;
using Apiwork.domain.Employees;
using Apiwork.domain.OPDs;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using Apiworks.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apiworks.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OPDController : ControllerBase
    {
        private DataContext _dataContext;
        public OPDController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {

            //var data = await _dataContext.opds.ToListAsync();
            //return Ok   (data);
            var data = await (from o in _dataContext.opds
                              join p in _dataContext.patients on o.PatientId equals p.Id


                              select new OPDLISTDto
                              {
                                  id = o.Id,
                                  date = o.date,
                                  validuptoDate = o.validuptoDate,
                                  invoiceNumber = o.invoiceNumber,
                                  DayNumber = o.DayNumber,
                                  DoctorId = o.DoctorId,
                                  opetorid = o.opetorid,
                                  description = o.description,
                                  Weight = o.Weight,
                                  BP = o.BP,
                                  Temp = o.Temp,
                                  Amount = o.Amount,
                                  Discount = o.Discount,
                                  ServiceId = o.ServiceId,


                              }).ToListAsync();
            return Ok(data);
        }

        [HttpGet("id")]
        public async Task<IActionResult>GetById(int id)
        {
            var data = await _dataContext.opds.FindAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult>Create(OPDDto input)
        {
           
            Patient pa = new Patient();
            {
                pa.Id = input.Id;
                pa.Name = input.Name;
                pa.Gender = input.Gender;
                pa.DOB = input.DOB;
                pa.MiritalStatus = input.MiritalStatus;
                pa.Address=input.Address;
                pa.Email = input.Email;
                pa.City = input.City;
                pa.MobileNo=input.MobileNo;
                _dataContext.patients.AddAsync(pa);
                _dataContext.SaveChanges();

            }
            opd op = new opd();
            {
                pa.Id = input.Id;
                op.date = input.date;
                op.validuptoDate = input.validuptoDate;
                op.invoiceNumber = input.invoiceNumber;
                op.DayNumber = input.DayNumber;
                op.opetorid = input.opetorid;
                op.description = input.description;
                op.Weight = input.Weight;
                op.BP = input.BP;
                op.Temp = input.Temp;
                op.Amount = input.Amount;
                op.Discount = input.Discount;
                op.DoctorId = input.DoctorId;
                op.ServiceId = input.Serviceid;

                await _dataContext.opds.AddAsync(op);
                _dataContext.SaveChanges();
            }
            //Service sr=new Service();
            //{
            //    sr.Id = input.Id;
            //    _dataContext.services.AddAsync(sr);
            //    _dataContext.SaveChanges();
            //}
            return Ok(input);
        
        }



    }

}
