using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    interface IEmployeesRepository : IRepository<Employee>
    {
        List<Employee> GetByName(string Name);
        List<Employee> GetPage(int skip, int take);
        int GetPersonsCount();
    }
}