using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zeww.Models;

namespace Zeww.BusinessLogic.DTOs
{
    public class WorkspaceRoleDTO
    {
        public int UserToBeChangedId { get; set; }
        public UserRoleInWorkspace UserRoleInWorkspace { get; set; }
    }
}
