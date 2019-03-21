using System;
using System.Collections.Generic;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IUserChatsRepository : IGenericRepository<UserChats>
    {
        //Your method headers go here
        UserChats GetUserChatByIds(int userID, int chatId);
    }
}

