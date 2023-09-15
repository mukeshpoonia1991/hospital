using Api.Data.Migrations;
using ApiWeb.Webapi.Dto.OPDs;
using ApiWeb.Webapi.Dto.Reports;
using Apiwork.Data.Data;
using Apiwork.domain.OPDs;
using Apiwork.domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly DataContext _datacontext;
        private readonly string _connection;

        public ReportController(DataContext datacontext, IConfiguration configuration)
        {
            _datacontext = datacontext;
            _connection = configuration.GetConnectionString("default");

        }
        [HttpGet]
        [Route("api/penel/Report/Dashboard")]

        public async Task<ActionResult<DashBoardReport>> Dashboard()
        {
            //  var output = await _datacontext.Database.("exec UspBoard").FirstorDefultAsync();

            var output = new DashBoardReport();
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("UspBoard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            output.TotalService = (int)reader["TotalService"];
                            output.TotalDoctor = (int)reader["TotalDoctor"];
                            output.TotalOtherStaff = (int)reader["TotalOtherStaff"];
                            output.TotalPatient = (int)reader["TotalPatient"];
                            output.WeekOpd = (int)reader["WeekOpd"];
                            output.TodayOpd = (int)reader["TodayOpd"];
                            output.TotalOpd = (int)reader["TotalOpd"];
                            output.TodayOpdAmount = (int)reader["TodayOpdAmount"];
                            output.TotalOpdAmount = (int)reader["TotalOpdAmount"];
                            output.WeekOpdAmount = (int)reader["WeekOpdAmount"];

                        }


                    }
                }
            }
            return Ok(output);
        }
        [HttpGet]
        [Route("api/penel/OPDCheck/date")]

        public ActionResult<Opd> opd( DateTime sdate, DateTime edate)
        {
            List<Opd> a = new List<Opd>();
            var b = _datacontext.opds.Where(r => r.Date >= sdate && r.Date <= edate).ToList();

          
            return Ok(b);
        }
        [HttpGet]
        [Route("api/penel/OPD/ServiceReport")]
        public ActionResult<opd>ServiceReport( DateTime sdate, DateTime edate) 
        {
            List<opd> a = new List<opd>();
            var data = _datacontext.services.Where(r => r.CreatedDate >= sdate && r.CreatedDate <= edate).ToList();
            return Ok(data);
        }


        [HttpGet]
        [Route("api/penel/DoctorReport")]

        public ActionResult<Opd> opd(string? Name, DateTime sdate, DateTime edate)
        {
            List<Opd> a = new List<Opd>();
            var b = _datacontext.opds.Where(r => r.employee.FirstName == Name || r.Date >= sdate && r.Date <= edate).ToList();

            //get data from database 
            return Ok(b);
        }
        [Route("api/pannel/PatientReport")]
        [HttpGet]
        public async Task<ActionResult<List<OPDDTO>>> Get(DateTime StartDate, DateTime EndDate, string? Name, Int64 MobileNO)
        {
            try
            {
                var output = from x in _datacontext.opds
                             join y in _datacontext.patients on x.PatientId equals y.Id
                             where (x.Date >= StartDate && x.Date <= EndDate || (y.Name == Name || y.MobileNo == MobileNO))
                             select new OPDDTO()
                             {
                                 Id = x.Id,
                                 Name = y.Name,
                                 Gender = y.Gender,
                                 DOB = y.DOB,
                                 MiritalStatus = y.MiritalStatus,
                                 MobileNo = y.MobileNo,
                                 Email = y.Email,
                                 Address = y.Address,
                                 City = y.City,
                                 Date = x.Date,
                                 ValiduptoDate = x.ValiduptoDate,
                                 InvoiceNumber = x.InvoiceNumber,
                                 DayNumber = x.DayNumber,

                                 DoctorId = x.DoctorId,
                                 OpetorId = x.OpetorId,
                                 Description = x.Description,
                                 Weight = x.Weight,
                                 BP = x.BP,
                                 Temp = x.Temp,
                                 Discount = x.Discount,
                                 ServiceId = x.ServiceId,


                                 Amount = x.Amount,


                             };
                var response = await output.ToListAsync();

                return Ok(response);
            }
            catch
            {
                return BadRequest("Error!!");
            }
        }












    }
}
