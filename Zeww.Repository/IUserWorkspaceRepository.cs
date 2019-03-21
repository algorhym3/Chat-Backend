using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IUserWorkspaceRepository : IGenericRepository<UserWorkspace> {

        //This is a junction table, do not add methods here
        IQueryable<UserWorkspace> GetWorkspacesByUserId(int id);
        IQueryable<UserWorkspace> GetUsersByWorkspaceId(int id);
        UserWorkspace GetUserWorkspaceByIds(int userId, int workspaceId);

    }
}
