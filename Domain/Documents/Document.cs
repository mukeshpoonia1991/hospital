using Apiwork.domain.Docuement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiwork.domain.Documents
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("documentType")]
        public int DocuementTypeID { get; set; }
        public DocumentType documentType { get; set; }
        public string Url { get; set; }
    }
}
