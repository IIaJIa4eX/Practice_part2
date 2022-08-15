using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;

namespace TimeShittyCompany.Services
{
    //for review
    public class UsersService : ControllerBase, IUsersService
    {
        private IUsersRepository _usersRepository;
        public UsersService(IUsersRepository personRepository)
        {
            _usersRepository = personRepository;
        }

        public string AddNewUser(User person)
        {
            string answer;
            if (person.Id == -1)
            {
                answer = "Некорректный id!";
            }
            else
            {
                try
                {
                    User tmpPerson = _usersRepository.GetById(person.Id);

                    if (tmpPerson != null)
                    {

                        answer = "Такой id уже есть, введите другой!";
                    }
                    else
                    {
                        _usersRepository.AddNewUser(person);

                        tmpPerson = _usersRepository.GetById(person.Id);
                        if (person.Equals(tmpPerson))
                        {
                            answer = "Новый клиент добавлен успешно!";
                        }
                        else
                        {
                            answer = "Ошибка! Кто-то добавил человека с таким id быстрее! Создание не удалось";
                        }

                    }
                }
                catch
                {
                    answer = "Ошибка! При создании клиента что-то пошло не так";
                }
               
            }

            return answer;
        }

        public string DeleteUserById(int id)
        {
            string answer;
            try
            {
                _usersRepository.DeleteUserById(id);

                User person = _usersRepository.GetById(id);

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

        public User GetById(int id)
        {
            User person = _usersRepository.GetById(id);

            if(person == null)
            {
                return new User() {Id = id };
            }

            return person;
        }

        public List<User> GetByName(string Name)
        {
            List<User> personsList;
            try
            {
                personsList = _usersRepository.GetByName(Name);
                
            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public List<User> GetPage(int skip, int take)
        {
            List<User> personsList;
            try
            {
                int count = _usersRepository.GetPersonsCount();
                if (skip > count || skip < 0 || take < 0)
                {
                    return null;
                }

                if (skip + take > count)
                {
                    personsList =  _usersRepository.GetPage(skip, count - skip);
                }

                personsList =  _usersRepository.GetPage(skip, take);
            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public List<User> GetUsersList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public string UpdateUserById(User person)
        {
            string answer;
            try
            {
                User tmpPerson = _usersRepository.GetById(person.Id);

                if (tmpPerson != null)
                {
                    _usersRepository.UpdateUserById(person);

                    tmpPerson = _usersRepository.GetById(person.Id);

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

        public IActionResult TestFunc()
        {

            return Ok("asd");
        }
    }

    
}
