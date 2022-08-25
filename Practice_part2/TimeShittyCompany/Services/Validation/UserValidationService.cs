using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.Services.Validation
{
    public sealed class UserValidationService : FluentValidationService<User>, IUserValidationService
    {
        IUsersRepository _userRep;
        public UserValidationService(IUsersRepository userRep)
        {
            _userRep = userRep;
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не должно быть пустым")
            .WithErrorCode("usr-001.0");
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустым")
            .WithErrorCode("usr-002.0");
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта не должна быть пустой")
            .WithErrorCode("usr-003.0");
            RuleFor(x => x.Email).Custom((s, context) =>
            {
                if (_userRep.IsEmailExist(s))
                {
                    context.AddFailure(new ValidationFailure(nameof(User.Email), "Пользователь c такой почтой уже существует")
                    {
                        ErrorCode = "usr-003.1"
                    });
                }
            });
            RuleFor(x => x.Age)
           .NotEmpty()
           .WithMessage("Возраст дожен быть указан")
           .WithErrorCode("usr-004");
            RuleFor(x => x.Age).Custom((age, context) =>
            {
                if (age < 0)
                {
                    context.AddFailure(new ValidationFailure(nameof(User.Age), "Возраст не может быть отрицательным")
                    {
                        ErrorCode = "usr-004.1"
                    });
                }
            });
        }


    }
}
