﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Common
{
    //for review
    public class User : CommonInfo
    {    
        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int Age
        {
            get; set;

        } = -1;
    }
}