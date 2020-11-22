using System.Web;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;

namespace PresentationYandexMusic.Areas.Admin.Validation.Album
{
    public class AdminValidationOfAlbumEdit : AbstractValidator<EditAlbumViewModel>
    {
        private readonly IAlbumDomainService albumDomain;
        private readonly ISingerDomainService singerDomain;

        public AdminValidationOfAlbumEdit(
            IAlbumDomainService albumDomain,
            ISingerDomainService singerDomain)
        {
            this.albumDomain = albumDomain;
            this.singerDomain = singerDomain;

            RuleFor(x => x.AlbumName)
                .NotEmpty().WithMessage("Введитете имя альбома")
                .MaximumLength(50).WithMessage("Альбом не может превысить 50 символов");

            RuleFor(x => x.SingerId)
                .Must(IsExistSinger).WithMessage("Такого исполнителя не существует");

            RuleFor(x => x.AlbumImage)
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");

            RuleFor(x => x)
                .Must(EditIsUniqueAlbum).WithMessage("Альбом с этим именем существует");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return albumDomain.IsJpg(file);
        }

        public bool EditIsUniqueAlbum(EditAlbumViewModel editAlbum)
        {
            return albumDomain.EditIsUniqueAlbum(editAlbum.Id, editAlbum.AlbumName);
        }

        public bool IsExistSinger(int id)
        {
            return singerDomain.IsExistSinger(id);
        }
    }
}