using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zeww.Models;
using Zeww.Repository;


namespace Zeww.DAL
{
    public class UnitOfWork : IUnitOfWork {

        ZewwDbContext context;
        

        public UnitOfWork() {
            DbContextOptionsBuilder<ZewwDbContext> optionsBuilder = new DbContextOptionsBuilder<ZewwDbContext>();
            string connection = @"Server=.;Database=ZewwDatabase;Trusted_Connection=True;ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connection);
            context = new ZewwDbContext(optionsBuilder.Options);
            Chats = new ChatRepository(context);
            UserChats = new UserChatsRepository(context);
            Messages = new MessageRepository(context);
            Users = new UserRepository(context);
            UserWorkspaces = new UserWorkspaceRepository(context);
            Workspaces = new WorkspaceRepository(context);
            Files = new FileRepository(context);
            UserChats = new UserChatsRepository(context);
        }

        public IChatRepository Chats { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IUserRepository Users { get; private set; }
        public IUserWorkspaceRepository UserWorkspaces { get; private set; }
        public IWorkspaceRepository Workspaces{ get; private set; }
        public IFileRepository Files { get; private set; }
        public IUserChatsRepository UserChats { get; private set; }


        public void Save() {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
    }
}
