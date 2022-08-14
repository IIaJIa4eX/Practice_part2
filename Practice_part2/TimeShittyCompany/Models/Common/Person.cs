using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Common
{
    //for review
    public class Person
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "Person doesn't exists";
        public string LastName { get; set; } = "Person doesn't exists";
        public string Email { get; set; } =  "Person doesn't exists";
        public string Company { get; set; } = "Person doesn't exists";
        public int Age
        {
            get; set;

        } = -1;
    }
}
