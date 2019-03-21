using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;
using Zeww.Repository;

namespace Zeww.DAL
{
    public class ChatRepository : GenericRepository<Chat>, IChatRepository {

        //This sets the context of the child class to the context of the super class
        public ChatRepository(ZewwDbContext context) : base(context) { }


        public void Insert(User userToAdd) {
            throw new NotImplementedException();
        }

        //Your methods go here
        
        public void addChat(Chat chatToAdd) {
            dbSet.Add(chatToAdd);
        }

        public bool EditChatTopic(int channelId, string topic)
        {
            try
            {
                var chatToUpdate = GetByID(channelId);
                chatToUpdate.Topic = topic;
                Update(chatToUpdate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured : " + e.ToString());
                return false;
            }
        }

        public void EditChannelName(int channelId, string newName)
        {
            Chat chat = GetByID(channelId);
            chat.Name = newName;
            Update(chat);
        }

        public int GetUnseenMessagesCount(int chatID, DateTime lastViewedByUser)
        {
            IQueryable<Chat> query = dbSet;
            var messages = query.Where(chat => chat.Id == chatID)
                .Include(chat => chat.Messages)
                .SelectMany(chat => chat.Messages);

            var UnseenMessagesCount = messages.Where(message => message.TimeStamp > lastViewedByUser).Count();

            return UnseenMessagesCount;
        }
    }
}
