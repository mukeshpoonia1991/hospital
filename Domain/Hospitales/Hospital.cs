using Api.Domain.Hospitales;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Apiwork.domain.Hospitales
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }
        
        public Int32 ResgisterNumber { get; set; }

        public Int64 ContactNumber { get; set; }

        public string MailId { get; set; }

        public string WebSite { get; set; }

        public HospitalAddress hospitalAddress { get; set; }
    }
}
