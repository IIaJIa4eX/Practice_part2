using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;

namespace TimeShittyCompany.DAL.Interfaces
{
    //_for review
    public interface IUsersRepository : IRepository<User>
    {
        
        List<User> GetByName(string Name);
        List<User> GetPage(int skip, int take);
        int GetPersonsCount();
        User CheckData(string email, string password);

        User FindToken(string token);


    }
}
