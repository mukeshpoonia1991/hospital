using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apiworks.Api.Dto.EmployessDto
{
    public class EmployessListDto
    {
        public int id { get; set; }

        public string FirstName { get; set; }
        public string MeddleName { get; set; }
        public string LastName { get; set; }

        public Int64 MobileNo { get; set; }
        public Int64 AlterNetMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public int EmployeeTypeid { get; set; }

        public string LoginCode { get; set; }
        public string DataofJoin { get; set; }

        public string DataOfBirth { get; set; }

        public string Createddate { get; set; }

        public int Creatorid { get; set; }

       

       


    }
}
