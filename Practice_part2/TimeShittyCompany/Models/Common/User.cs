using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Common
{
    //_for review

    [Table("Users")]
    public class User : CommonInfo
    {    
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Age
        {
            get; set;

        } = -1;

        public string Token { get; set; } = string.Empty;
        public  DateTime Expires { get; set; } = DateTime.Now;
    }
}
