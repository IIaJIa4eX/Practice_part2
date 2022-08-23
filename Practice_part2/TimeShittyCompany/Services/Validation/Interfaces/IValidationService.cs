using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeShittyCompany.Services.Validation.Interfaces
{
    public interface IValidationService<TEntity> where TEntity : class
    {
        IReadOnlyList<IOperationFailure> ValidateEntity(TEntity item);
    }



}
