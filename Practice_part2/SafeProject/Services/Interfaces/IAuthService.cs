using SafeProject.Models.Authorization;

namespace SafeProject.Services.Interfaces
{
    public interface IAuthService
    {
        AuthResponse Login(AuthRequest authRequest);

        public SessionInfo GetSessionInfo(string sessionToken);
        //string Authenticate(string email, string password);

        //JwtTokenResponse Authenticate_TokenResp(string email, string password);
        //string RefreshToken(string token);
    }
}
