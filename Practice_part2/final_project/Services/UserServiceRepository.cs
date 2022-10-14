using final_project.DAL;
using final_project.DAL.Entities;
using final_project.Models;
using final_project.Services.DTO;

namespace final_project.Services
{
    //for_review
    public class UserServiceRepository : IUserServiceRepository
    {

        private readonly DBConnection _context;


        public UserServiceRepository(DBConnection context)
        {
            _context = context;
        } 

        public UserResponse Add(UserAddRequestViewModel user)
        {

            
            User tmp = new User()
            {
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                Patronymic = user.Patronymic
            };
            _context.Users.Add(tmp);
            int count = _context.SaveChanges();

            if(count > 0)
            {
                return new UserResponse()
                {
                    Name = user.Name,
                    Email = user.Email,
                    Message = "Success",
                    ResponseCode = 200
                };
            }

            return new UserResponse()
            {
                Name = user.Name,
                Email = user.Email,
                Message = "Error",
                ResponseCode = 666
            };
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Where(us => us.Id == id).FirstOrDefault();
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public UserResponse Edit(User request)
        {
            var tmpuser = GetUser(request.Id);

            if (tmpuser.Message != "Success")
            {
                return new UserResponse()
                {
                    Name = "NotFound",
                    Email = "NotFound",
                    Message = "Error",
                    ResponseCode = 666
                };
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);

            user.Name = request.Name;
            user.Patronymic = request.Patronymic;
            user.LastName = request.LastName;
            user.Email = request.Email;

            if (_context.SaveChanges() > 0)
            {
                return new UserResponse()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                    Message = "User updated",
                    ResponseCode = 201
                };
            };

            return new UserResponse()
            {
                Name = "NotFound",
                Email = "NotFound",
                Message = "Error",
                ResponseCode = 666
            };
        }

        public List<User> GetAll()
        {
            return _context.Users.Take(10).ToList();
        }

        public UserResponse GetUser(int id)
        {
            var tmpUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if(tmpUser == null)
            {
                return new UserResponse()
                {
                    Name = "NotFound",
                    Email = "NotFound",
                    Message = "NotFound",
                    ResponseCode = 666
                };
            }

            return new UserResponse()
            {
                Id = tmpUser.Id,
                Name = tmpUser.Name,
                Email = tmpUser.Email,
                Message = "Success",
                ResponseCode = 201
            };
        }

        

    }
}
