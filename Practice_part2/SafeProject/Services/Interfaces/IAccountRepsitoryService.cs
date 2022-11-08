using Grpc.Core;
using SafeProject.Models;
using static ClientServiceProtos.ClientService;
using ClientServiceProtos;

namespace SafeProject.Services.Interfaces
{
    //for_review
    public interface IAccountRepsitoryService
    {
        CommonAccountResponse CreateAccount(CreateAccountRequest req);

        Task<GetClientResponse> GetByEmail(GetClientRequest req, ServerCallContext serverCall);
    }
}
