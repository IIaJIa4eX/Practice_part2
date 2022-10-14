using SafeProject.Models;
using SafeProject.Services.Interfaces;
using SafeProjectDBLib;
using SafeProjectDBLib.Entities;

namespace SafeProject.Services.Repositories
{
    //for_review
    public class AccountRepsitory : IAccountRepsitoryService
    {
        private readonly CardStorageDbConnection _context;
        public AccountRepsitory(CardStorageDbConnection context)
        {
            _context = context;
        }

        public CommonAccountResponse CreateAccount(CreateAccountRequest request)
        {
            Account account = _context.Accounts
                .Where(acc => acc.Emal == request.Emal)
                .FirstOrDefault();

            if(account == null)
            {
                _context.Add(new Account()
                {
                    Emal = request.Emal,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password,
                    SecondName = request.SecondName
                });
                _context.SaveChanges();

                return new CommonAccountResponse()
                {
                     Message = "Success",
                     ErrorCode = 201
                };
            }

            return new CommonAccountResponse()
            {
                Message = "Error",
                ErrorCode = 401
            };
        }
    }
}
