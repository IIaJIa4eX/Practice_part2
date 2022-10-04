using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Authorization;

namespace TimeShittyCompany.Services.Interfaces
{
    //for review
    public interface IAuthService
    {
        string Authenticate(string email, string password);

        JwtTokenResponse Authenticate_TokenResp(string email, string password);
        string RefreshToken(string token);
    }
}
