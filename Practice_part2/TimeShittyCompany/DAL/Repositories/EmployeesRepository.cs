using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public void Add(Employee p)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetPage(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int GetPersonsCount()
        {
            throw new NotImplementedException();
        }

        public void UpdateById(Employee person)
        {
            throw new NotImplementedException();
        }
    }
}
