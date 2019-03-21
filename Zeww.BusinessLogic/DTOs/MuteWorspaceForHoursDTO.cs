using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zeww.BusinessLogic.DTOs
{
    public class MuteWorspaceForHoursDTO
    {
        [Required]
        public int WorkspaceID { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double HoursToBeMuted { get; set; }
    }
}
