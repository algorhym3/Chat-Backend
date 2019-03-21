using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;
using Zeww.Repository;

namespace Zeww.DAL
{
    class UserChatsRepository : GenericRepository<UserChats>, IUserChatsRepository
    {
        public UserChatsRepository(ZewwDbContext context) : base(context) { }

        public UserChats GetUserChatByIds(int userId, int chatId)
        {
            IQueryable<UserChats> query = dbSet;

            return query.Where(uc => uc.UserId == userId && uc.ChatId == chatId).SingleOrDefault();
        }
    }
}
