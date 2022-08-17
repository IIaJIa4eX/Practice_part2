﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Common
{
    //_for review
    public class CommonInfo
    {    
            public int Id { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;

            public bool isDeleted { get; set; } = false;
      
    }
}
