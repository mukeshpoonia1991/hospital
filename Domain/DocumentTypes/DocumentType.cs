using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace Apiwork.domain.Docuement
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    
        


        

    }
}
