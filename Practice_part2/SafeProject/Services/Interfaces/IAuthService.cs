using SafeProject.Models.Authorization;

namespace SafeProject.Services.Interfaces
{
    //for_review
    public interface IAuthService
    {
        AuthResponse Login(AuthRequest authRequest);

        public SessionInfo GetSessionInfo(string sessionToken);
 
    }
}
