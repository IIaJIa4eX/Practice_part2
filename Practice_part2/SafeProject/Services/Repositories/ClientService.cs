using ClientServiceProtos;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using SafeProject.Services.Interfaces;
using static ClientServiceProtos.ClientService;

namespace SafeProject.Services.Repositories
{
    public class ClientService : ClientServiceBase
    {
        private readonly IAccountRepsitoryService _accountRepsitoryService;

        public ClientService(IAccountRepsitoryService accountRepsitoryService)
        {
            _accountRepsitoryService = accountRepsitoryService;
        }


        public override Task<GetClientResponse> GetByEmail(GetClientRequest req, ServerCallContext serverCall)
        {
            try
            {
                var client = _accountRepsitoryService.GetByEmail(req.Email);

                if (client.AccountId != -1)
                {
                    return Task.FromResult(new GetClientResponse
                    {
                        Id = client.AccountId,
                        ErrorCode = 200,
                        ErrorMessage = client.Message
                    });

                }
                return Task.FromResult(new GetClientResponse
                {
                    Id = -1,
                    ErrorCode = 404,
                    ErrorMessage = $"Client with Email {req.Email} does't exist"
                });

            }
            catch (Exception e)
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
