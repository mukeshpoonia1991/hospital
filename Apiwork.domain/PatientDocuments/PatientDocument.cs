using Apiwork.domain.Documents;
using Apiwork.domain.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.PatientDocuments
{
    public class PatientDocument
    {
        public int Id { get; set; }
        [ForeignKey("patient")]
        public int PatientID { get; set; }
        public Patient patient { get; set; }
        [ForeignKey("document")]
        public int DocumentID { get; set; }
        public Document document { get; set; }
    }
}
