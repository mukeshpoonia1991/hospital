using Apiwork.domain.Employees;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiworks.Api.Dto
{
    public class OPDDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }   
        public string MiritalStatus { get; set; }
        public Int64 MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime date { get; set; }
        public DateTime validuptoDate { get; set; }
        public int invoiceNumber { get; set; }
        public int DayNumber { get; set; }
     
        public int DoctorId { get; set; }
    
        public int PatientId { get; set; }
        public int opetorid { get; set; }
        public string description { get; set; }
        public string Weight { get; set; }
        public string BP { get; set; }
        public string Temp { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Serviceid { get; set; }

       

    }
}
