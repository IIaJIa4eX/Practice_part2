using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.DBConnect;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.DAL.Repositories
{
    //_for review
    public class EmployeesRepository : IEmployeesRepository
    {

        private readonly DBConnection _context;
        public EmployeesRepository(DBConnection context)
        {
            _context = context;
        }
        public void Add(Employee p)
        {
            _context.employeeEntity.Add(p);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            _context.employeeEntity.Where(
                tmpPerson => tmpPerson.Id == id
                )
                .FirstOrDefault()
                .isDeleted = true;
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            return _context.employeeEntity.Where(
                tmpPerson => tmpPerson.Id == id && tmpPerson.isDeleted == false)
                .FirstOrDefault();
        }

        public List<Employee> GetByName(string Name)
        {
            return _context.employeeEntity.Where(
                tmpPerson => tmpPerson.FirstName == Name
                && tmpPerson.isDeleted == false)
                .ToList();
        }

        public List<Employee> GetList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetPage(int skip, int take)
        {
            return _context.employeeEntity.Skip(skip)
                .Take(take)
                .Where(tmpPerson => tmpPerson.isDeleted == false)
                .ToList();
        }

        public int GetPersonsCount()
        {
            return _context.employeeEntity.Count();
        }

        public void UpdateById(Employee person)
        {
            Employee perToUpdate = _context.employeeEntity.Where(tmpPerson => tmpPerson.Id == person.Id).FirstOrDefault();
            perToUpdate.Age = person.Age;
            perToUpdate.Email = person.Email;
            perToUpdate.FirstName = person.FirstName;
            perToUpdate.LastName = person.LastName;
            perToUpdate.Company = person.Company;
            _context.SaveChanges();
        }

    }
}
