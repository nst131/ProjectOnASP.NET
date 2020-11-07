using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminAlbumPresentationService : IAdminBasePresentationService
    {
        void AddAlbum(CreateAlbumViewModel albumView);
        void DeleteAlbum(int id);
        void DeleteTrackFileByAlbumId(int id);
        void EditAlbum(EditAlbumViewModel albumView);
        CreateAlbumViewModel GetCreateAlbumViewModel();
        CreateAlbumViewModel GetCreateAlbumViewModel(CreateAlbumViewModel albumView);
        DeleteAlbumViewModel GetDeleteAlbumViewModel(int id);
        EditAlbumViewModel GetEditAlbumViewModel(int id);
        EditAlbumViewModel GetEditAlbumViewModel(EditAlbumViewModel editAlbum);
        bool IsExistAlbum(int id);
        AlbumImage RedirectAlbumImage(int id);
    }
}
