using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Zeww.Models;
using Zeww.Repository;

namespace Zeww.DAL
{
    public class FileRepository : GenericRepository<File>, IFileRepository
    {

        //This sets the context of the child class to the context of the super class
        public FileRepository(ZewwDbContext context) : base(context) { }

        //Your methods go here
        public void Add(File fileToAdd)
        {
            dbSet.Add(fileToAdd);
        }
        public IEnumerable<File> GetFilesFromChat(string chatName)
        {
            return Get(File => (File.Chat.Name == chatName));
        }
        public IEnumerable<File> GetFiles(string chatName , string senderName  , string topic)
        {
            if (!String.IsNullOrEmpty(chatName))
            {
                IQueryable<File> filesToReturn = GetFilesFromChat(chatName).AsQueryable();
                if (!String.IsNullOrEmpty(senderName))
                {
                    filesToReturn = filesToReturn.Where(FilterBySenderName(senderName));
                }
                if(!String.IsNullOrEmpty(senderName))
                {
                    filesToReturn = filesToReturn.Where(FilterByTopic(topic));
                }
                return filesToReturn;
            }
            else
                return null;
        }
        //Filter Expression for Getting files by sender name
        private Expression<Func<File, bool>> FilterBySenderName(string name)
        {
            return File => (File.User.Name == name);
        }
        //Filter Expression for Getting files by topic
        private Expression<Func<File, bool>> FilterByTopic(string topic)
        {
            return File => (File.Chat.Topic == topic);
        }
    }
}
