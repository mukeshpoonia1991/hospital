using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Apiwork.domain.Services
{
    public class ServiceType
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }    

        public bool IsActived { get; set; }



    }
}
