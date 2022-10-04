using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.Services.Validation
{
    // for review
    public class OperationFailure : IOperationFailure
    {
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
