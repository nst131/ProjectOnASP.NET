using PresentationYandexMusic.Areas.Admin.ViewModel;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminGenrePresentationService : IAdminBasePresentationService
    {
        void AddGenre(GenreViewModel genreModel);
    }
}