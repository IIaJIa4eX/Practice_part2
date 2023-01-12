using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.DAL.Context
{    //for review

    public interface IDatabaseContextService
    {
        IList<Book> Books { get; }
    }
}
