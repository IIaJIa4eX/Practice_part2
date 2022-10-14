using final_project.DAL.Entities;
using final_project.Models;
using final_project.Services.DTO;

namespace final_project.Services
{
    public interface IUserServiceRepository
    {
        UserResponse Add(UserAddRequestViewModel user);

        UserResponse Edit(User request);

        UserResponse GetUser(int id);

        bool Delete(int id);

        List<User> GetAll();

    }
}
