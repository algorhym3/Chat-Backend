using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IUserRepository : IGenericRepository<User> {

        //Your method headers go here
        User GetUserByUserName(string name);
        User GetUserByEmail(string email);
        bool Authenticate(User user, string claimedPassword);
        string GenerateJWTToken(User user);
        IQueryable<int> GetChatsIdsByUserId(int id);
        IQueryable<int> GetWorkspaceIdsByUserId(int id);
    }
}
