using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    public interface IPersonRepository
    {

        Person GetById(int id);
        Person GetByName(string Name);
        List<Person> GetPersonsList(int skip, int take);
        string AddNewPerson();
        string UpdatePersonById(int id);
        string DeletePersonById(int id);


    }
}
