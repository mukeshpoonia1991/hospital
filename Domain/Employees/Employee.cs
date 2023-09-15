using Apiwork.domain.EmployesLogin;
using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace Apiwork.domain.Employees
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string MeddleName { get; set; }
        public string LastName { get; set; }

        public Int64 MobileNo { get; set; }
        public Int64 AlterNetMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        [ForeignKey("employeeType")]
        public int EmployeeTypeId { get; set; }

        public EmployeeType employeeType { get; set; }

        public DateTime DataOfJoin { get; set; }

        public DateTime DataOfBirth { get; set; }

        public DateTime Createddate { get; set; }

        public int Creatorid { get; set; }

        public EmployeeLogin employesLogin { get; set; }









    }
}
