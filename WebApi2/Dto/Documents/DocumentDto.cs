using Apiwork.domain.Docuement;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWeb.Webapi.Dto.Documents
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public int DocuementTypeID { get; set; }
        public string Url { get; set; }
    }
}
