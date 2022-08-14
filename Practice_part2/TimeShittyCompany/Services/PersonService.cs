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
    public class PersonService : ControllerBase, IPersonService
    {
        private IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public string AddNewPerson(Person person)
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
                    Person tmpPerson = _personRepository.GetById(person.Id);

                    if (tmpPerson != null)
                    {

                        answer = "Такой id уже есть, введите другой!";
                    }
                    else
                    {
                        _personRepository.AddNewPerson(person);

                        tmpPerson = _personRepository.GetById(person.Id);
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

        public string DeletePersonById(int id)
        {
            string answer;
            try
            {
                _personRepository.DeletePersonById(id);

                Person person = _personRepository.GetById(id);

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

        public Person GetById(int id)
        {
            Person person = _personRepository.GetById(id);

            if(person == null)
            {
                return new Person() {Id = id };
            }

            return person;
        }

        public List<Person> GetByName(string Name)
        {
            List<Person> personsList;
            try
            {
                personsList = _personRepository.GetByName(Name);
                
            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public List<Person> GetPage(int skip, int take)
        {
            List<Person> personsList;
            try
            {
                int count = _personRepository.GetPersonsCount();
                if (skip > count || skip < 0 || take < 0)
                {
                    return null;
                }

                if (skip + take > count)
                {
                    personsList =  _personRepository.GetPage(skip, count - skip);
                }

                personsList =  _personRepository.GetPage(skip, take);
            }
            catch
            {
                return null;
            }

            return personsList;
        }

        public List<Person> GetPersonsList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public string UpdatePersonById(Person person)
        {
            string answer;
            try
            {
                Person tmpPerson = _personRepository.GetById(person.Id);

                if (tmpPerson != null)
                {
                    _personRepository.UpdatePersonById(person);

                    tmpPerson = _personRepository.GetById(person.Id);

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
