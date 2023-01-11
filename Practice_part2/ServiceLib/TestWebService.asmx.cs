using ServiceLib.DAL.Context;
using ServiceLib.DAL.Repos;
using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceLib
{
    /// <summary>
    /// Сводное описание для TestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {

        private readonly IRepositoryBooks _booksRepo;

        public TestWebService()
        {
            _booksRepo = new RepositoryBooks(new DataBaseContext());
        }


        [WebMethod]
        public Book[] GetBooksByTitle(string title)
        {
            return _booksRepo.GetByTitle(title).ToArray();
        }

        [WebMethod]
        public Book[] GetBooksByAuthor(string authorName)
        {
            return _booksRepo.GetByAuthor(authorName).ToArray();
        }

        [WebMethod]
        public Book[] GetBooksByCategory(string category)
        {
            return _booksRepo.GetByCategory(category).ToArray();
        }

    }
}
