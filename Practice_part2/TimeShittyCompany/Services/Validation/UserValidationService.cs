using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeShittyCompany.Models.Common;
using TimeShittyCompany.Services.Interfaces;
using TimeShittyCompany.Services.Validation.Interfaces;

namespace TimeShittyCompany.Services.Validation
{
    public sealed class UserValidationService : FluentValidationService<User>, IUserValidationService
    {
        IUsersService _userService;
        public UserValidationService(IUsersService userService)
        {
            _userService = userService;
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не должно быть пустым")
            .WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустым")
            .WithErrorCode("BRL-100.2");
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта не должна быть пустой")
            .WithErrorCode("BRL-100.3");
            RuleFor(x => x.Email).Custom((s, context) =>
            {
                if (_userService.IsEmailExist(s))
                {
                    context.AddFailure(new ValidationFailure(nameof(User.FirstName), "Пользователь c такой почтой уже существует")
{
                        ErrorCode = "BRL-100.4"
                    });
                }
            });
            RuleFor(x => x.Age)
           .NotEmpty()
           .WithMessage("Возраст дожен быть указан")
           .WithErrorCode("BRL-100.5");
        }

        
    }
}
