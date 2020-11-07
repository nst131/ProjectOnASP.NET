using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;
using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Validation.Singer
{
    public class AdminValidationOfSingerEdit : AbstractValidator<EditSingerViewModel>
    {
        private readonly ISingerDomainService singerDomainService;

        public AdminValidationOfSingerEdit(ISingerDomainService singerDomain)
        {
            this.singerDomainService = singerDomain;

            RuleFor(x => x.SingerName)
                .NotEmpty().WithMessage("Введитете имя исполнителя")
                .MaximumLength(50).WithMessage("Исполнитель не может превысить 50 символов");

            RuleFor(x => x.SingerImage)
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");

            RuleFor(x => x)
                .Must(EditIsUniqueSinger).WithMessage("Исполнитель уже существует");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return singerDomainService.IsJpg(file);
        }

        public bool EditIsUniqueSinger(EditSingerViewModel viewModel)
        {
            return singerDomainService.EditIsUniqueSinger(viewModel.Id,viewModel.SingerName);
        }
    }
}