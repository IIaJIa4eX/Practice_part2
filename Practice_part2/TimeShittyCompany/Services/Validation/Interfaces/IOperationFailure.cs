﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Services.Validation.Interfaces
{
    public interface IOperationFailure
    {
        string PropertyName { get; }
        string Description { get; }
        string Code { get; }
    }
}
