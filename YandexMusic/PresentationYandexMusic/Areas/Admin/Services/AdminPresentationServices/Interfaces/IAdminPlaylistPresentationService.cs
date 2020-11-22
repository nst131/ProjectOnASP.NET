using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.ViewModel.Playlist;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminPlaylistPresentationService : IAdminBasePresentationService
    {
        void AddPlaylist(CreatePlaylistViewModel playlistModel);

        void DeletePlaylist(int id);

        DeletePlaylistViewModel GetDeletePlaylistViewModel(int id);

        bool IsExistPlaylist(int id);

        PlaylistImage RedirectPlaylistImage(int id);
    }
}