using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Zeww.Models;
using Zeww.Repository;

namespace Zeww.DAL
{
    public class UserWorkspaceRepository : GenericRepository<UserWorkspace>, IUserWorkspaceRepository {
        //This sets the context of the child class to the context of the super class
        public UserWorkspaceRepository(ZewwDbContext context) : base(context) { }

        //This is a junction table, no methods go here!
        public IQueryable<UserWorkspace> GetWorkspacesByUserId(int id)
        {
            IQueryable<UserWorkspace> query = dbSet;
            return query.Where(u => u.UserId == id);
        }
        public IQueryable<UserWorkspace> GetUsersByWorkspaceId(int id)
        {
            IQueryable<UserWorkspace> query = dbSet;
            return query.Where(w => w.WorkspaceId == id);
        }
        public UserWorkspace GetUserWorkspaceByIds(int userId, int workspaceId)
        {
            IQueryable<UserWorkspace> query = dbSet;

            return query.Where(uc => uc.UserId == userId && uc.WorkspaceId == workspaceId).SingleOrDefault();
        }
    }
}
