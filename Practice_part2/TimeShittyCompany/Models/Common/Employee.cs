﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Models.Common
{
    //_for review
    [Table("Employees")]
    public class Employee : CommonInfo
    {

        public string Email { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
        public int Age
        {
            get; set;

        } = -1;
    }
}
