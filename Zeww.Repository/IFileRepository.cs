using System;
using System.Collections.Generic;
using System.Text;
using Zeww.Models;

namespace Zeww.Repository
{
    public interface IFileRepository : IGenericRepository<File>
    {
        //Your method headers go here
        IEnumerable<File> GetFiles(string chatName , string senderName , string topic);

        void Add(File FileToAdd);
        IEnumerable<File> GetFilesFromChat(string chatName);
    }
}
