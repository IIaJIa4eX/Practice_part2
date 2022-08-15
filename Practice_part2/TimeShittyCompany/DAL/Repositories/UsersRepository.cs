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
    public class UsersRepository : IUsersRepository
    {
        private readonly List<User> _persons;
        IDataGenerator _dataGenerator;
        public UsersRepository(IDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
            _persons = _dataGenerator.GetPersonData();
           
        }

        public void AddNewUser(User person)
        {
            _persons.Add(person);
        }

        public void DeleteUserById(int id)
        {
            _persons.RemoveAll(person => person.Id == id);
        }

        public User GetById(int id)
        {

            return _persons.Where(person => person.Id == id).FirstOrDefault();
            
        }

        public List<User> GetByName(string Name)
        {
            return _persons.Where(person => person.FirstName == Name).ToList();
        }

        public int GetPersonsCount()
        {
            return _persons.Count();
        }
        public List<User> GetPage(int skip, int take)
        {
            return _persons.Skip(skip).Take(take).ToList();
        }

        public List<User> GetUsersList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserById(User person)
        {
            User perToUpdate =_persons.Where(tmpPerson => tmpPerson.Id == person.Id).FirstOrDefault();
            perToUpdate.Age = person.Age;
            perToUpdate.Email = person.Email;
            perToUpdate.FirstName = person.FirstName;
            perToUpdate.LastName = person.LastName;
            perToUpdate.Company = person.Company;
        }
    }
}
