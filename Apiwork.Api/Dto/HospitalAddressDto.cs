using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiworks.Api.Dto
{
    public class HospitalAddressDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public string Logo { get; set; }

        public Int32 ResgisterNumber { get; set; }

        public Int64 ContactNumber { get; set; }

        public int hospitalId { get; set; }

        public string MailId { get; set; }

        public string WebSide { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string city { get; set; }

        public int pincode { get; set; }

        public string Logitude { get; set; }

        public string latitude { get; set; }
    }
}
