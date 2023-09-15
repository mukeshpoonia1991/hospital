using Apiwork.domain.Employees;
using Apiwork.domain.Employees;
using Apiwork.domain.Patients;
using Apiwork.domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.OPDs
{
    public class opd
    {
        [Key]
        public int Id { get; set; }

            public DateTime date { get; set; }

            public DateTime validuptoDate { get; set; }

            public int invoiceNumber { get; set; }

            public int DayNumber { get; set; }

            [ForeignKey("patient")]
            public int PatientId { get; set; }

            public Patient patient { get; set; }

            [ForeignKey("employe")]
            public int DoctorId { get; set; }

            public Employe employe { get; set; }

            public int opetorid { get; set; }

            public string description { get; set; }

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
