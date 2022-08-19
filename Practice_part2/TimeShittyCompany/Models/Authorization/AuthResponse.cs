using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Authorization
{
    internal sealed class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }

}
