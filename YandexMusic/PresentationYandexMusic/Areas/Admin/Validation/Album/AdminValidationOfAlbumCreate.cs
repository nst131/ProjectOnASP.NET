using System.Web;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;

namespace PresentationYandexMusic.Areas.Admin.Validation.Album
{
    public class AdminValidationOfAlbumCreate : AbstractValidator<CreateAlbumViewModel>
    {
        private readonly IAlbumDomainService albumDomain;
        private readonly ISingerDomainService singerDomain;

        public AdminValidationOfAlbumCreate(
            IAlbumDomainService albumDomain,
            ISingerDomainService singerDomain)
        {
            this.albumDomain = albumDomain;
            this.singerDomain = singerDomain;

            RuleFor(x => x.AlbumName)
                .NotEmpty().WithMessage("Введитете имя альбома")
                .MaximumLength(50).WithMessage("Альбом не может превысить 50 символов")
                .Must(IsUniqueAlbum).WithMessage("Альбом уже существует");

            RuleFor(x => x.SingerId)
                .Must(IsExistSinger).WithMessage("Такого исполнителя не существует");

            RuleFor(x => x.AlbumImage)
                .NotEmpty().WithMessage("Картинка не выбрана")
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return albumDomain.IsJpg(file);
        }

        public bool IsUniqueAlbum(string albumName)
        {
            return albumDomain.IsUniqueAlbum(albumName);
        }

        public bool IsExistSinger(int id)
        {
            return singerDomain.IsExistSinger(id);
        }
    }
}