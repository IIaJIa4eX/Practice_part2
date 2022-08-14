using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    //for review
    public interface IPersonRepository
    {

        Person GetById(int id);
        List<Person> GetByName(string Name);
        List<Person> GetPersonsList(int skip, int take);
        void AddNewPerson(Person p);
        void UpdatePersonById(Person person);
        void DeletePersonById(int id);
        List<Person> GetPage(int skip, int take);
        int GetPersonsCount();


    }
}
