using FluentValidation;
using PresentationYandexMusic.Models.HomeModels;

namespace PresentationYandexMusic.Validation
{
    public class ValidationOfLoginViewModel : AbstractValidator<LoginViewModel>
    {
        public ValidationOfLoginViewModel()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Введите имя пользователя")
                .MaximumLength(50).WithMessage("Имя пользователя превышает допустимое число символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Введите пароль");
        }
    }
}