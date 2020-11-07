using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using FluentValidation;
using PresentationYandexMusic.Areas.Admin.ViewModel.Playlist;
using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Validation.Playlist
{
    public class AdminValidationOfPlaylistCreate : AbstractValidator<CreatePlaylistViewModel>
    {
        private readonly IPlaylistDomainService playlistDomain;

        public AdminValidationOfPlaylistCreate(IPlaylistDomainService playlistDomain)
        {
            this.playlistDomain = playlistDomain;

            RuleFor(x => x.PlaylistName)
                .NotEmpty().WithMessage("Введитете имя плэйлиста")
                .MaximumLength(50).WithMessage("Плэйлист не может превысить 50 символов")
                .Must(IsUniquePlaylist).WithMessage("Плэйлист уже существует");

            RuleFor(x => x.PlaylistImage)
                .NotEmpty().WithMessage("Картинка не выбрана")
                .Must(IsJpg).WithMessage("Картинка должна иметь тип jpg");
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return playlistDomain.IsJpg(file);
        }

        public bool IsUniquePlaylist(string playlistName)
        {
            return playlistDomain.IsUniquePlaylist(playlistName);
        }
    }
}