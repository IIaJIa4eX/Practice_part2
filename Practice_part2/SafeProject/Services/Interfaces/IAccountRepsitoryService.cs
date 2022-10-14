using SafeProject.Models;

namespace SafeProject.Services.Interfaces
{
    public interface IAccountRepsitoryService
    {
        CommonAccountResponse CreateAccount(CreateAccountRequest req);
    }
}
