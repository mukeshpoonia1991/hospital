using Apiwork.domain.Hospitales;
using Apiwork.domain.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiworks.Api.Dto
{
    public class ServiceDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int discountable { get; set; }

        public int ServiceTypeId { get; set; }

        

        public string Creatorid { get; set; }

        public DateTime createdDate { get; set; }

        public string ValidDay { get; set; }

     

        public int Hospitalid { get; set; }
     

    }
}
