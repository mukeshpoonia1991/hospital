using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiworks.Api.Dto.EmployessDto
{
    public class CreateUpdateEmployesDto
    {
        public int id { get; set; }

        public string FirstName { get; set; }
        public string MeddleName { get; set; }
        public string LastName { get; set; }

        public long MobileNo { get; set; }
        public long AlterNetMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public int EmployesTypeID { get; set; }

        //public string  EmployesTypeName { get; set; }

        public string DataOfBirth { get; set; }

        public string LoginCode { get; set; }

        public int Password { get; set; }

        public string dataofJoin { get; set; }

        public string Createddate { get; set; }

        public int Creatorid { get; set; }
        public int HospitalId { get; set; }




    }
}
