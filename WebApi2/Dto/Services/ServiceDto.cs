using Apiwork.domain.Hospitales;
using Apiwork.domain.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWeb.Webapi.Dto.Services
{
    public class ServiceDto
    {
        

        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =4,ErrorMessage ="Please Check youe Name" )]
        public string Name { get; set; }
        [Required]
        
        public int Amount { get; set; }


        public int Discountable { get; set; }
        public int ServiceTypeId { get; set; }
        public string Creatorid { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ValidDay { get; set; }
        public int Hospitalid { get; set; }


    }




}

