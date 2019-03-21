using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.BusinessLogic.DTOs
{
    public class DoNotDisturbDTO
    {
        [Required]
        [Range(0, 23)]
        public int DoNotDisturbFrom { get; set; }
        [Required]
        [Range(0, 23)]
        public int DoNotDisturbTo { get; set; }
    }
}
