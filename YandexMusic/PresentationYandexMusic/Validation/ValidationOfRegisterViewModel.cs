using FluentValidation;
using PresentationYandexMusic.Models.HomeModels;

namespace PresentationYandexMusic.Validation
{
    public class ValidationOfRegisterViewModel : AbstractValidator<RegisterViewModel>
    {
        public ValidationOfRegisterViewModel()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Введите имя пользователя")
                .MaximumLength(50).WithMessage("Имя пользователя превышает допустимое число символов");
            ////Check admin in CustomUserValidation
            ////Check Unique UserName in UserValidator

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Введите пароль");
            ////Check Password length in CustomPasswordValidation

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Введите email");
            ////Check Email in CustomUserValidation
            ////Check Unique Email in UserValidator
        }
    }
}