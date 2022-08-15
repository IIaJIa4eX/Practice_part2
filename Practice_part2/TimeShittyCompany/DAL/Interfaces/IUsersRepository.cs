using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    //for review
    public interface IUsersRepository : IRepository<User>
    {

        
        List<User> GetByName(string Name);
        List<User> GetUsersList(int skip, int take);
        List<User> GetPage(int skip, int take);
        int GetPersonsCount();


    }
}
