using Newtonsoft.Json;
using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ServiceLib.DAL.Context
{
    //for review
    public class DataBaseContext : IDatabaseContextService
    {
        private IList<Book> _libraryDatabase;

        public IList<Book> Books { get { return _libraryDatabase; } }


        public DataBaseContext()
        {
            Initialize();
        }

        private void Initialize()
        {
            _libraryDatabase = JsonConvert.DeserializeObject<List<Book>>(Encoding.UTF8.GetString(ServiceLib.Properties.Resources.books));
        }
    }
}