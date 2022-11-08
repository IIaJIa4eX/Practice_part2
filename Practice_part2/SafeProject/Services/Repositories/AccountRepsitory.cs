using ClientServiceProtos;
using Grpc.Core;
using SafeProject.Models;
using SafeProject.Services.Interfaces;
using SafeProjectDBLib;
using SafeProjectDBLib.Entities;
using System.Runtime.InteropServices;

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

        public Task<GetClientResponse> GetByEmail(GetClientRequest req, ServerCallContext serverCall)
        {
            try
            {
                var client = _context.Accounts.FirstOrDefault(c => c.Emal == req.Email);

                if(client != null)
                {
                    return Task.FromResult(new GetClientResponse
                    {
                        Id = client.AccountId,
                        ErrorCode = 200,
                        ErrorMessage = String.Empty
                    });

                }
                return Task.FromResult(new GetClientResponse
                {
                    Id = -1,
                    ErrorCode = 404,
                    ErrorMessage = $"Client with Email {req.Email} does't exist"
                });

            }
            catch(Exception e)
            {
                return Task.FromResult(new GetClientResponse
                {
                    Id = -1,
                    ErrorCode = 666,
                    ErrorMessage = e.Message
                });
            }
        }
    }
}
