using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;
using Zeww.Repository;

namespace Zeww.DAL {
    public class MessageRepository: GenericRepository<Message>, IMessageRepository {
        //This sets the context of the child class to the context of the super class
        public MessageRepository(ZewwDbContext context) : base(context) { }

        //Your methods go here

        public void Add(Message message)
        {
            message.TimeStamp = DateTime.Now;
            dbSet.Add(message);
        }

        public IQueryable<Message> GetMessagesbyChatId(int id, int n)
        {
            IQueryable<Message> MessageList = dbSet.Where(c => c.ChatId == id).Skip(n).Take(5);
            return MessageList;

        }

        //ERROR HERE, Message returns null
        public void DeleteMessage(int id)
        {
            Message message = dbSet.SingleOrDefault(m => m.Id == id);
            dbSet.Remove(message);
        }

    public void PinMessage(int messageId)
        {
            var messageToPin = GetByID(messageId);
            messageToPin.isPinned = true;
            Update(messageToPin);
        }
    }


}