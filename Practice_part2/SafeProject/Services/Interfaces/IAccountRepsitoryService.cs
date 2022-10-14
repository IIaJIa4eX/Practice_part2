using SafeProject.Models;

namespace SafeProject.Services.Interfaces
{
    //for_review
    public interface IAccountRepsitoryService
    {
        CommonAccountResponse CreateAccount(CreateAccountRequest req);
    }
}
