using Apiwork.domain.Employees;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWeb.Webapi.Dto.OPDs
{
    public class OPDDTO
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

        public DateTime Date { get; set; }

        public DateTime ValiduptoDate { get; set; }

        public int InvoiceNumber { get; set; }

        public int DayNumber { get; set; }


      

        public int DoctorId { get; set; }
        public int OpetorId { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public string BP { get; set; }

        public string Temp { get; set; }

        public int Amount { get; set; }

        public int Discount { get; set; }

        public int ServiceId { get; set; }



    }
}
