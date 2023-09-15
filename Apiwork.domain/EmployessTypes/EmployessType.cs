using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.EmployessTypes
{
    public class EmployessType
    {
        [Key]
        public int Id { get; set; }

        public string name {get;set; }
    }
}
