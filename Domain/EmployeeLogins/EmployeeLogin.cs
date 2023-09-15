using Apiwork.domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.EmployesLogin
{
    public  class EmployeeLogin
    {
        [Key]

        public int Id { get; set; }

        public string Code { get; set; }

        public String Password { get; set; }


        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
