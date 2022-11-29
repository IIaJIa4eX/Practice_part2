using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeProject.Models.Authorization
{
    //for review
    public sealed class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }

}
