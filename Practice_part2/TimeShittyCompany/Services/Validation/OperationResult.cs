using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.Services.Validation
{
    // for review
    public class OperationResult<TResult> : IOperationResult<TResult>  where TResult : class
    {
        public TResult Result { get; set; }

        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        public bool Succeed { get; set; }
    }
}
