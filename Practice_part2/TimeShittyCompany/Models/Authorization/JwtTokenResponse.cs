using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Authorization
{
    //for review
    public sealed class JwtTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
