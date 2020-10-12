using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Validation
{
    public class AdminValidationOfGenreCreate : AbstractValidator<GenreViewModel>
    {
        private readonly IGenreDomainService genreDomain;

        public AdminValidationOfGenreCreate(IGenreDomainService genreDomain)
        {
            this.genreDomain = genreDomain;

            RuleFor(x => x.GenreName)
                .NotEmpty().WithMessage("Введитете имя жанра")
                .MaximumLength(50).WithMessage("Жанр не может превысить 50 символов")
                .Must(IsUniqueGenre).WithMessage("Жанр уже существует");

            RuleFor(x => x.GenreImage)
                .NotEmpty().WithMessage("Картинка не выбрана")
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return genreDomain.IsJpg(file);
        }

        public bool IsUniqueGenre(string genreName)
        {
            return genreDomain.IsUniqueGenre(genreName);
        }
    }
}