using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IWorkspaceRepository : IGenericRepository<Workspace> {

        //Your method headers go here
        Workspace GetWorkspaceByName(string name);
        IQueryable<int> GetUsersIdInWorkspace(int id);
        IQueryable<UserChats> GetChatsIdByUserAndWorkspace(int userID, int workSpaceID);
        ICollection <Chat> GetAllChannelsInAworkspace(int workspaceId);
    }
}
