using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Add(T p);
        void UpdateById(T person);
        void DeleteById(int id);
    }
}
