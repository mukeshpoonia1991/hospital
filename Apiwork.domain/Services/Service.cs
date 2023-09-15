using Apiwork.domain.Hospitales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Services
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }   
        
        public int Amount { get; set; }

        public int discountable { get; set; }

        [ForeignKey("serviceType")]
        public int ServiceTypeId { get; set; }

        public ServiceType serviceType { get; set; }

        public string Creatorid { get; set; }

        public DateTime createdDate { get; set; }

        public string ValidDay { get; set; }

        [ForeignKey("hospital")]
        public int Hospitalid { get; set; }
        public Hospital hospital { get; set; }



    }
}
