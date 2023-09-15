using System.ComponentModel.DataAnnotations;

namespace Apiwork.domain.Depatemants
{
    public class Department
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }


    }
}
