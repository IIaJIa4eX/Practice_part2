using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Authorization
{
    public sealed class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }

}
