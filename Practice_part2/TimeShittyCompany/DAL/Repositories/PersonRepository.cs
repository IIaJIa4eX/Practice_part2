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

    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _persons;
        public PersonRepository()
        {

        }

        public string AddNewPerson()
        {
            throw new NotImplementedException();
        }

        public string DeletePersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Person GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersonsList(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public string UpdatePersonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
