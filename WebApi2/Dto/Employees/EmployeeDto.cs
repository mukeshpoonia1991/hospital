using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ApiWeb.Webapi.Dto.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =4,ErrorMessage ="Please Check youe Name" )]

        public string FirstName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Please Check youe Name")]

        public string MeddleName { get; set; }
        public string LastName { get; set; }

        [Required]
       [Phone]
        public Int64 MobileNo { get; set; }

        [Required]
        [Phone]
        public Int64 AlterNetMobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        public string Gender { get; set; }

        public DateTime DataOfJoin { get; set; }

        public DateTime DataOfBirth { get; set; }

        public DateTime Createddate { get; set; }

        public int Creatorid { get; set; }

        public int EmployeeTypeId { get; set; }
        [Required]
        [Range (4, 10)]
        public string Code { get; set; }
        [Required]
        [Range(4,10) ]
        public string Password { get; set; }

     

    }
}
