using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.DAL.Repos
{
    public interface IRepositoryBooks : IRepositoryDefault<Book, string>
    {
        IList<Book> GetByTitle(string title);

        IList<Book> GetByAuthor(string authorName);

        IList<Book> GetByCategory(string category);
    }
}
