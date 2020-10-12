using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Validation
{
    public class AdminValidationOfSingerCreate : AbstractValidator<SingerViewModel>
    {
        private readonly ISingerDomainService singerDomainService;

        public AdminValidationOfSingerCreate(ISingerDomainService singerDomain)
        {
            this.singerDomainService = singerDomain;

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