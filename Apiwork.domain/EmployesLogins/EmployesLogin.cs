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
    public  class EmployesLogin
    {
        [Key]

        public int Id { get; set; }

        public string Code { get; set; }

        public int password { get; set; }

        [ForeignKey("employe")]
        public int EmployesId { get; set; }
        public Employe employe { get; set; }
    }
}
