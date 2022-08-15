using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    //for review
    public interface IUsersRepository
    {

        User GetById(int id);
        List<User> GetByName(string Name);
        List<User> GetUsersList(int skip, int take);
        void AddNewUser(User p);
        void UpdateUserById(User person);
        void DeleteUserById(int id);
        List<User> GetPage(int skip, int take);
        int GetPersonsCount();


    }
}
