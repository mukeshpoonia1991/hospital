using Apiwork.domain.EmployessTypes;
using Apiwork.domain.Hospitales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apiwork.domain.Employees
{
    public class Employe
    {
        [Key]

        public int id { get; set; }
        
        public string FirstName { get; set; }
        public string MeddleName { get; set; }
        public string LastName { get; set; }

         public Int64 MobileNo { get; set; } 
         public Int64 AlterNetMobileNo { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        [ForeignKey("employessTypes")]
        public int EmployeeTypeid { get; set; }

        public EmployessType employessTypes { get; set; }

        public string DataofJoin { get; set; }

        public string DataOfBirth { get; set; }

        public string Createddate { get; set; }

        public int Creatorid { get; set; }

        [ForeignKey("hospital")]
        public int HospitalId { get; set; }
        public Hospital hospital { get; set; }



 





    }
}
