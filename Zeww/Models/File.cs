using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Url]
        public string Source { get; set; }
        public string Name { get; set; }
        //public long Size { get; set; }
        public string Extension { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
