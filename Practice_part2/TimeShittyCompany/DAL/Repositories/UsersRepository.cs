using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.DBConnect;
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
        private readonly DBConnection _context;
        public UsersRepository(IDataGenerator dataGenerator, DBConnection context)
        {
            _context = context;
            _dataGenerator = dataGenerator;
            _persons = _dataGenerator.GetPersonData();
           
        }

        public void Add(User person)
        {
            _context.userEntity.Add(person);
            _context.SaveChanges();

        }

        public void DeleteById(int id)
        {
            _persons.RemoveAll(person => person.Id == id);
        }

        public User GetById(int id)
        {

            return _context.userEntity.Where(user => user.Id == id).FirstOrDefault();
            
        }

        public List<User> GetByName(string Name)
        {
            return _context.userEntity.Where(person => person.FirstName == Name).ToList();
        }

        public int GetPersonsCount()
        {
            return _context.userEntity.Count();
        }
        public List<User> GetPage(int skip, int take)
        {
            return _context.userEntity.Skip(skip).Take(take).ToList();
        }


        public void UpdateById(User person)
        {
            User perToUpdate = _context.userEntity.Where(tmpPerson => tmpPerson.Id == person.Id).FirstOrDefault();
            perToUpdate.Age = person.Age;
            perToUpdate.Email = person.Email;
            perToUpdate.FirstName = person.FirstName;
            perToUpdate.LastName = person.LastName;
            perToUpdate.Company = person.Company;
            _context.SaveChanges();
        }
    }
}
