using Apiwork.domain.HospitalAddress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Hospitales
{
    public class Hospital
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string Logo { get; set; }

        public Int32 ResgisterNumber { get; set; }

        public HospitalAddres hospitalAddress { get; set; }
    }
}
