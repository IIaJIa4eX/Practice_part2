using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.Services.Interfaces
{
    //for review
    public interface IPersonService
    {
        Person GetById(int id);
        List<Person> GetByName(string Name);
        List<Person> GetPersonsList(int skip, int take);
        string AddNewPerson(Person person);
        string UpdatePersonById(Person person);
        string DeletePersonById(int id);

        List<Person> GetPage(int skip, int take);

        IActionResult TestFunc();

    }
}
