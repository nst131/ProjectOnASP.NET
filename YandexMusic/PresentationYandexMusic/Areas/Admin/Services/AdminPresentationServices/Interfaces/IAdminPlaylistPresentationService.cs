using PresentationYandexMusic.Areas.Admin.ViewModel;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminPlaylistPresentationService : IAdminBasePresentationService
    {
        void AddPlaylist(PlaylistViewModel playlistModel);
    }
}