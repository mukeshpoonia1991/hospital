using Apiwork.domain.Docuement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Documents
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("docuementType")]
        public int DocuementTypeID { get; set; }
        public DocuementType docuementType { get; set; }
        public string Url { get; set; }
    }
}
