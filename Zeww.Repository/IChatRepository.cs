using System;
using System.Collections.Generic;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IChatRepository : IGenericRepository<Chat> {

        //Your method headers go here
        void Insert(User userToAdd);
        void addChat(Chat chatToAdd);

        bool EditChatTopic(int channelId , string topic);

        void EditChannelName(int channelId, string newName);

        int GetUnseenMessagesCount(int chatID, DateTime lastViewedByUser);
    }
}
