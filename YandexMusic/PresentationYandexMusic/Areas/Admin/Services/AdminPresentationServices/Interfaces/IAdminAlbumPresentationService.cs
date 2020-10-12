using PresentationYandexMusic.Areas.Admin.ViewModel;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminAlbumPresentationService : IAdminBasePresentationService
    {
        void AddAlbum(AlbumViewModel albumView);
        AlbumViewModel GetAlbumViewModel();
    }
}
