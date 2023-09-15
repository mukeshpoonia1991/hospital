using Apiwork.domain.Depatemants;
using Apiwork.domain.Employees;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace Apiwork.domain.EmployesDepatements
{
    public class EmployeeDepartment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("employee")]
        public int EmployeId { get; set; }

        public Employee employee { get; set; }

        [ForeignKey("department")]

        public int DepatementId { get; set; }

        public Department department { get; set; }



    }
}
