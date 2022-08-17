using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.Services.Interfaces
{
    //_for review
    public interface IUsersService
    {
        User GetById(int id);
        List<User> GetByName(string Name);
        List<User> GetUsersList(int skip, int take);
        string AddNewUser(User person);
        string UpdateUserById(User person);
        string DeleteUserById(int id);

        List<User> GetPage(int skip, int take);

        IActionResult TestFunc();

    }
}
