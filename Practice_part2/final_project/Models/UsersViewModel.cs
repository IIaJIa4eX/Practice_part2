using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace final_project.Models
{
    public class UsersViewModel : IValidatableObject
    {

        [Required(ErrorMessage = "Фамилия является обязательной.")]
        [Display(Name = "Фамилия")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Максимальная длина строки 100 символов, минимальная длина строки 2 символа.")]
        [RegularExpression(@"([А-ЯЁ][а-яё\-0-9]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имела неверный формат.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Имя должно быть заполнено!")]
        [Display(Name = "Имя")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Максимальная длина строки 100 символов, минимальная длина строки 2 символа.")]
        [RegularExpression(@"([А-ЯЁ][а-яё\-0-9]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имела неверный формат.")]
        public string? Name { get; set; }
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Почта должна быть указана!")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Почта имеет неправильный формат")]
        [Display(Name = "Почта")]
        public string? Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LastName == "Иванов")
                yield return new ValidationResult("Иванов должен быть старше 30 лет.", new[] { nameof(LastName) });

            //yield return ValidationResult.Success!;
        }
    }
    
}
