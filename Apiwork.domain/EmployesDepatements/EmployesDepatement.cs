using Apiwork.domain.Depatemants;
using Apiwork.domain.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.EmployesDepatements
{
    public class EmployesDepatement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("employe")]
        public int EmployeId { get; set; }

        public Employe empolye { get; set; }

        [ForeignKey("depatemant")]

        public int DepatementId { get; set; }

        public Depatemant depatemant { get; set; }


        
    }
}
