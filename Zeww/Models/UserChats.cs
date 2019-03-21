    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.Models
{
    public class UserChats
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int ChatId { get; set; }
        public bool IsStarred { get; set; }
        public bool IsMuted { get; set; }
        public DateTime LastViewedByUser { get; set; }
    }
}
