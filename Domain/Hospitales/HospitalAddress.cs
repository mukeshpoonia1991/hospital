using Apiwork.domain.Hospitales;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Hospitales
{
    public class HospitalAddress
    {
        [Key]
        public int Id { get; set; }


        public int HospitalId { get; set; }

        public Hospital hospital { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string city { get; set; }

        public string State { get; set; }

        public int pincode { get; set; }

        public string Logitude { get; set; }

        public string latitude { get; set; }
    }
}
