using Apiwork.domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.OTPes
{
    public class OTP
    {
        [Key]

        public int Id { get; set; }

        public int CODE { get; set; }

        public DateTime ExpirationTime { get; set; }
        [ForeignKey("employee")]
        public int EmployessID { get; set; }

        public Employee employee { get; set; }


    }
}
