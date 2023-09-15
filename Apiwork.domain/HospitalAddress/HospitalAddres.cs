using Apiwork.domain.Hospitales;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.HospitalAddress
{
    public class HospitalAddres
    {
        [Key]
        public int id { get; set; }

      
        public int hospitalId { get; set; }

        public Hospital hospital { get; set; }

        public Int64 ContactNumber { get; set; }

        public string MailId { get; set; }

        public string WebSide { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string city { get; set; }

        public int pincode { get; set; }

        public string Logitude { get; set; }

        public string latitude { get; set; }
    }
}
