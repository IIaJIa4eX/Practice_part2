using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Models.Responses;
using TimeShittyCompany.Utils;

namespace TimeShittyCompany.Repositories
{
    //for review
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _persons;
        IDataGenerator _dataGenerator;
        public PersonRepository(IDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
            _persons = _dataGenerator.GetPersonData();
           
        }

        public void AddNewPerson(Person person)
        {
            _persons.Add(person);
        }

        public void DeletePersonById(int id)
        {
            _persons.RemoveAll(person => person.Id == id);
        }

        public Person GetById(int id)
        {

            return _persons.Where(person => person.Id == id).FirstOrDefault();
            
        }

        public List<Person> GetByName(string Name)
        {
            return _persons.Where(person => person.FirstName == Name).ToList();
        }

        public int GetPersonsCount()
        {
            return _persons.Count();
        }
        public List<Person> GetPage(int skip, int take)
        {
            return _persons.Skip(skip).Take(take).ToList();
        }

        public List<Person> GetPersonsList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void UpdatePersonById(Person person)
        {
            Person perToUpdate =_persons.Where(tmpPerson => tmpPerson.Id == person.Id).FirstOrDefault();
            perToUpdate.Age = person.Age;
            perToUpdate.Email = person.Email;
            perToUpdate.FirstName = person.FirstName;
            perToUpdate.LastName = person.LastName;
            perToUpdate.Company = person.Company;
        }
    }
}
