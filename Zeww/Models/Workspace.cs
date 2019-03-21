using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zeww.Models {
    public class Workspace {
        public Workspace() {
            this.UserWorkspaces = new HashSet<UserWorkspace>();
        }
  
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        public string WorkspaceName { get; set; }
        [ForeignKey("User")]
        public int CreatorID { get; set; }

        public string CompanyName { get; set; }

        public string WorkspaceProjectName { get; set; }

        public string DateOfCreation { get; set; }

        public string URL { get; set; }
        [Range(0, 23)]
        public int? DailyDoNotDisturbFrom { get; set; }
        [Range(1, 23)]
        public int? DailyDoNotDisturbTo { get; set; }

        public bool IsEmailVisible { get; set; }

        public string WorkspaceImageId { get; set; }

        public string WorkspaceImageName { get; set; }

        public virtual ICollection<UserWorkspace> UserWorkspaces { get; set; }
        public bool CanInviteUsersToWorkspace { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }


}