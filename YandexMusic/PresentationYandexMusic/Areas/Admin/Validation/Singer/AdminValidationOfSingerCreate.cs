using System.Web;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;

namespace PresentationYandexMusic.Areas.Admin.Validation.Singer
{
    public class AdminValidationOfSingerCreate : AbstractValidator<CreateSingerViewModel>
    {
        private readonly ISingerDomainService singerDomainService;

        public AdminValidationOfSingerCreate(ISingerDomainService singerDomain)
        {
            singerDomainService = singerDomain;

            RuleFor(x => x.SingerName)
                .NotEmpty().WithMessage("Введитете имя жанра")
                .MaximumLength(50).WithMessage("Исполнитель не может превысить 50 символов")
                .Must(IsUniqueSinger).WithMessage("Исполнитель уже существует");

            RuleFor(x => x.SingerImage)
                .NotEmpty().WithMessage("Картинка не выбрана")
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return singerDomainService.IsJpg(file);
        }

        public bool IsUniqueSinger(string singerName)
        {
            return singerDomainService.IsUniqueSinger(singerName);
        }
    }
}