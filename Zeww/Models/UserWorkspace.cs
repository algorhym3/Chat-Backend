using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.Models
{
    public class UserWorkspace
    {
        [Key]
        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public User User { get; set; }
        [Key]
        public int WorkspaceId { get; set; }
        //[ForeignKey("WorkspaceId")]
        //public Workspace Workspace { get; set; }
        public DateTime TimeToWhichNotificationsAreMuted { get; set; }
        public UserRoleInWorkspace UserRoleInWorkspace { get; set; }
    }

    public enum UserRoleInWorkspace
    {
        Owner,
        Admin,
        Member,
        Guest
    }
}
