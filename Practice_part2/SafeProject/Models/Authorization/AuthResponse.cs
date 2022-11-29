using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeProject.Models.Authorization
{
    //for review
    public sealed class AuthResponse
    {
        public AuthStatus AuthStatus { get; set; }
        //public RefreshToken? LatestRefreshToken { get; set; }
        public SessionInfo? SessionInfo { get; set; }
    }

}
