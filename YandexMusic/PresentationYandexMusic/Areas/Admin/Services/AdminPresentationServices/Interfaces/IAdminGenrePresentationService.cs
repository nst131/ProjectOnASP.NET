using PresentationYandexMusic.Areas.Admin.ViewModel.Genre;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminGenrePresentationService : IAdminBasePresentationService
    {
        void AddGenre(CreateGenreViewModel genreModel);
    }
}