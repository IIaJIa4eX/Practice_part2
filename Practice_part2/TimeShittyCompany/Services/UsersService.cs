using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Models.Responses;
using TimeShittyCompany.Services.Interfaces;
using TimeShittyCompany.Services.Validation;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.Services
{
    //_for review
    public class UsersService : ControllerBase, IUsersService
    {
        private IUsersRepository _usersRepository;
        private readonly IUserValidationService _validationService;
        public UsersService(IUsersRepository personRepository, IUserValidationService validationService)
        {
            _usersRepository = personRepository;
            _validationService = validationService;
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
                        _usersRepository.Add(person);

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
                catch (Exception e)
                {

                    answer = $"Ошибка! При создании клиента что-то пошло не так: {e.Message}";
                }
               
            }

            return answer;
        }

        public string DeleteUserById(int id)
        {
            string answer;
            try
            {
                _usersRepository.DeleteById(id);

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
                    _usersRepository.UpdateById(person);

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

        public bool IsEmailExist(string email)
        {

               return _usersRepository.IsEmailExist(email);

        }

        public IOperationResult<UserResponse> AddNewUserValidation(User person)
        {
            var failures = _validationService.ValidateEntity(person);
            if(failures.Count > 0)
            {
                return new OperationResult<UserResponse> {
                    Failures = failures,
                    Succeed = false,
                    Result = null};
            }
          

            try
            {
                User tmpPerson = _usersRepository.GetById(person.Id);

                if (tmpPerson != null)
                {

                    return new OperationResult<UserResponse>
                    {
                        Failures = failures,
                        Succeed = false,
                        Result = new UserResponse()
                        {
                            Message = "Такой id уже есть, введите другой!"
                        }
                    };
                 }
                else
                {
                    _usersRepository.Add(person);

                    tmpPerson = _usersRepository.GetById(person.Id);
                    if (person.Equals(tmpPerson))
                    {
                        return new OperationResult<UserResponse>
                        {
                            Failures = null,
                            Succeed = true,
                            Result = new UserResponse {
                                Message = "Ура! Человек создан",
                                ResponseBody = new UserDTO {
                                    FirsName = tmpPerson.FirstName,
                                    Age = tmpPerson.Age,
                                    Email = tmpPerson.Email }
                            }
                        };
                    }
                    else
                    {
                        return new OperationResult<UserResponse>
                        {
                            Failures = failures,
                            Succeed = false,
                            Result = new UserResponse()
                            {
                                Message = "Ошибка! Кто-то добавил человека с таким id быстрее! Создание не удалось"
                            }
                        };
                      
                    }

                }
            }
            catch (Exception e)
            {


                return new OperationResult<UserResponse>
                {
                    Failures = failures,
                    Succeed = false,
                    Result = new UserResponse()
                    {
                        Message = $"Ошибка! При создании клиента что-то пошло не так: {e.Message}"
                    }
                };

                 
            }

        }
    }

    
}
