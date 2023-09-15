using ApiWeb.Webapi.Dto.Departments;
using Apiwork.Data.Data;
using Apiwork.domain.Depatemants;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace ApiWeb.Webapi.Controllers
{


    [ApiController]
    public class DepartmentController : ControllerBase

    {
        //[Authorize(Roles = "Admin")]
        private readonly DataContext _dataContext;

        private readonly IMapper _mapper;

        public DepartmentController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [Route("api/panel/department")]

        [HttpGet]
        public async Task<ActionResult<List<DepartmentDto>>> Get()
        {
            var output = await _dataContext.departments.ToListAsync();

            var list = _mapper.Map<List<DepartmentDto>>(output);

            return list;
        }

        [Route("api/panel/department/{id}")]

        [HttpGet]

        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var data = await _dataContext.departments.FindAsync(id);
            var output = _mapper.Map<DepartmentDto>(data);
            return output;
        }
        [Route("api/panel/department/")]
        [HttpPost]

        public async Task<ActionResult<DepartmentDto>> Post(CreateUpdateDepartmentDto input)
        {
            Department department = _mapper.Map<Department>(input);
            _dataContext.departments.Add(department);
            await _dataContext.SaveChangesAsync();
            string body = $"Project Create''";

            var output = _mapper.Map<DepartmentDto>(department);



            return output;
        }


        [Route("api/panel/department/{id}")]
        [HttpPut]
        public async Task<ActionResult<DepartmentDto>> put(CreateUpdateDepartmentDto input, int id)
        {
            Department department = await _dataContext.departments.FindAsync(id);
            if (department == null)
            {
                BadRequest("data not working");
            }
            department.Name = input.Name;

            _dataContext.departments.Update(department);

            await _dataContext.SaveChangesAsync();

            var output = _mapper.Map<DepartmentDto>(department);
            return output;
        }

        [Route("api/panel/department/{id}")]

        [HttpDelete]
        public async void Delete(int id)
        {
            Department department = _dataContext.departments.Find(id);
            if (department == null)
            {
                BadRequest("");
            }

            _dataContext.departments.Remove(department);
            await _dataContext.SaveChangesAsync();
        }
        [Route("api/panel/department/gmail")]

      [HttpPost]
       private void SendEmail(string mukeshpoonia1991, string subject, string body)
       {
           using (var message = new MailMessage())
           {
               message.To.Add(new MailAddress("mukeshpoonia1991@gmail.com"));
               message.From = new MailAddress("yuvagoonjtrust@gmail.com");
               message.Subject = subject;
               message.Body = body;
               message.IsBodyHtml = true;

               using (var client = new SmtpClient("smtp.gmail.com", 587))
               {
                   client.EnableSsl = true;
                   client.UseDefaultCredentials = false;
                   client.Credentials = new NetworkCredential("yuvagoonjtrust@gmail.com", "JayShreeRam@1002");

                   client.Send(message);
               }
           }

       }


}
    /* public IActionResult SendEmail(string toEmail, string subject, string body)
     {
         using (var message = new MailMessage())
         {
             message.To.Add(new MailAddress(toEmail));
             message.From = new MailAddress("rockeypoonia1609@gmail.com");
             message.Subject = subject;
             message.Body = body;
             message.IsBodyHtml = true;

             using (var client = new SmtpClient("smtp.gmail.com", 587))
             {
                 client.EnableSsl = true;
                 client.UseDefaultCredentials = false;
                 client.Credentials = new NetworkCredential("rockeypoonia1609@gmail.com", "yhnrbvooszxskdjw");

                 client.Send(message);
             }
         }

         return Ok("Email sent successfully!");
     }


 }*/



}


      
 

   


