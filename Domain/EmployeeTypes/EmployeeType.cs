using System.ComponentModel.DataAnnotations;

namespace Apiwork.domain.EmployessTypes
{
    public class EmployeeType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
