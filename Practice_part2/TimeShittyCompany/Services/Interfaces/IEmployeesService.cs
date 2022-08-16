using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.Services.Interfaces
{
    interface IEmployeesService
    {

            Employee GetById(int id);
            List<Employee> GetByName(string Name);
            List<Employee> GetEmployeesList(int skip, int take);
            string AddNewEmployee(Employee employee);
            string UpdateEmployeeById(Employee employee);
            string DeleteEmployeeById(int id);

            List<Employee> GetPage(int skip, int take);
            

        
    }
}
