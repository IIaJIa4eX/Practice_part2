using ClientServiceProtos;
using Grpc.Core;
using SafeProject.Models;
using SafeProject.Services.Interfaces;
using SafeProjectDBLib;
using SafeProjectDBLib.Entities;
using System.Runtime.InteropServices;
using static ClientServiceProtos.ClientService;

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

        public CommonAccountResponse GetByEmail(string email)
        {
            var client = _context.Accounts.FirstOrDefault(c => c.Emal == email);

            if(client == null)
            {
                return new CommonAccountResponse()
                {
                    AccountId = -1,
                    ErrorCode = 404,
                    Message = "NotFound"
                };
            }

            return new CommonAccountResponse()
            {
                AccountId = client.AccountId,
                ErrorCode = 200,
                Message = "Success"
            };

        }
    }
}
