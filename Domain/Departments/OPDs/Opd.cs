using Apiwork.domain.Employees;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiwork.domain.OPDs
{
    public class Opd
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime ValiduptoDate { get; set; }

        public int InvoiceNumber { get; set; }

        public int DayNumber { get; set; }

        [ForeignKey("patient")]
        public int PatientId { get; set; }

        public Patient patient { get; set; }

        [ForeignKey("employee")]
        public int DoctorId { get; set; }

        public Employee employee { get; set; }

        public int OpetorId { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }

        public string BP { get; set; }

        public string Temp { get; set; }

        public int Amount { get; set; }

        public int Discount { get; set; }

        [ForeignKey("service")]

        public int ServiceId { get; set; }

        public Service service { get; set; }

    }
}
