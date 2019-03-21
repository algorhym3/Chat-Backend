using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.Models
{
    public class Chat {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Workspace")]
        public int WorkspaceId { get; set; }
        [ForeignKey("User")]
        public int CreatorID { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        public string Name { get; set; }

        //For viewing message threads
        public int skip { get; set; } = 0;

        //Purpose should only be added in the case of group channels
        public string Purpose { get; set; }
        public string Topic { get; set; }
        public virtual ICollection<UserChats> UserChats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        public Chat()
        {
            this.UserChats = new HashSet<UserChats>();
            this.DateCreated = DateTime.Now;
        }
    }
}
