using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository {
    public interface IMessageRepository : IGenericRepository<Message> {

        void Add(Message message);
        IQueryable<Message> GetMessagesbyChatId(int id, int n);
        void DeleteMessage(int id);
        void PinMessage(int messageId);

    }
}
