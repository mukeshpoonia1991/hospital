using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Depatemants
{
    public  class Depatemant
    {
        [Key]

        public int Id { get; set; }

        public string DepatemantName { get; set; }

       
    }
}
