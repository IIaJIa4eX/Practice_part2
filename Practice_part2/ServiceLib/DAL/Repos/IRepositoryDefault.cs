using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.DAL.Repos
{    //for review

    public interface IRepositoryDefault<T, TId>
    {
        int? Add(T item);

        int Update(T item);

        int Delete(T item);

        IList<T> GetAll();

        T GetById(TId id);
    }
}
