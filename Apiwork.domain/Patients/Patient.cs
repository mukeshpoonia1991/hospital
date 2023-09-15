using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Patients
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string MiritalStatus { get; set; }

        public Int64 MobileNo { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}
