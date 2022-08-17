using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Services
{
    public class EmployeesService : IEmployeesService
    {

        private IEmployeesRepository _employeeRepository;
        public EmployeesService(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string AddNewEmployee(Employee employee)
        {
            string answer;
            if (employee.Id == -1)
            {
                answer = "Некорректный id!";
            }
            else
            {
                try
                {
                    Employee tmpPerson = _employeeRepository.GetById(employee.Id);

                    if (tmpPerson != null)
                    {

                        answer = "Такой id уже есть, введите другой!";
                    }
                    else
                    {
                        _employeeRepository.Add(employee);

                        tmpPerson = _employeeRepository.GetById(employee.Id);
                        if (employee.Equals(tmpPerson))
                        {
                            answer = "Новый сотрудник добавлен успешно!";
                        }
                        else
                        {
                            answer = "Ошибка! Кто-то добавил человека с таким id быстрее! Создание не удалось";
                        }

                    }
                }
                catch (Exception e)
                {

                    answer = $"Ошибка! При создании струдника что-то пошло не так: {e.Message}";
                }

            }

            return answer;
        }

        public string DeleteEmployeeById(int id)
        {
            string answer;
            try
            {
                _employeeRepository.DeleteById(id);

                Employee person = _employeeRepository.GetById(id);

                if (person != null)
                {

                    answer = "Удаление не удалось!";
                }
                else
                {
                    answer = "Удаление прошло успешно!";
                }
            }
            catch
            {
                answer = "При удалении произошла ошибка!";
            }


            return answer;
        }

        public Employee GetById(int id)
        {
            Employee person = _employeeRepository.GetById(id);

            if (person == null)
            {
                return new Employee() { Id = id };
            }

            return person;
        }

        public List<Employee> GetByName(string Name)
        {
            List<Employee> personsList;
            try
            {
                personsList = _employeeRepository.GetByName(Name);

            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public List<Employee> GetEmployeesList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetPage(int skip, int take)
        {
            List<Employee> personsList;
            try
            {
                int count = _employeeRepository.GetPersonsCount();
                if (skip > count || skip < 0 || take < 0)
                {
                    return null;
                }

                if (skip + take > count)
                {
                    personsList = _employeeRepository.GetPage(skip, count - skip);
                }

                personsList = _employeeRepository.GetPage(skip, take);
            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public string UpdateEmployeeById(Employee employee)
        {
            string answer;
            try
            {
                Employee tmpPerson = _employeeRepository.GetById(employee.Id);

                if (tmpPerson != null)
                {
                    _employeeRepository.UpdateById(employee);

                    answer = "Обновление прошло успешно";

                }
                else
                {
                    answer = "Такого клиента нет!";
                }

            }
            catch
            {
                answer = "Ошибка! При обновлении что-то пошло не так";
            }

            return answer;
        }
    }
}
