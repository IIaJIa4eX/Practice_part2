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
    //_for review
    public class UsersRepository : IUsersRepository
    {
        private readonly DBConnection _context;
        public UsersRepository(DBConnection context)
        {
            _context = context;           
        }

        public void Add(User person)
        {
            _context.userEntity.Add(person);
            _context.SaveChanges();

        }

        public void DeleteById(int id)
        {
            _context.userEntity.Where(
                tmpPerson => tmpPerson.Id == id
                )
                .FirstOrDefault()
                .isDeleted = true;
            _context.SaveChanges();
        }

        public User GetById(int id)
        {

            return _context.userEntity.Where(
                user => user.Id == id && user.isDeleted == false)
                .FirstOrDefault();
            
        }

        public List<User> GetByName(string Name)
        {
            return _context.userEntity.Where(
                person => person.FirstName == Name
                && person.isDeleted == false)
                .ToList();
        }

        public int GetPersonsCount()
        {
            return _context.userEntity.Count();
        }
        public List<User> GetPage(int skip, int take)
        {
            return _context.userEntity.Skip(skip)
                .Take(take)
                .Where(user => user.isDeleted == false)
                .ToList();
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
