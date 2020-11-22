using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.GenreModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IGenrePresentationService : IBasePresentationService
    {
        GenreViewModel GetGenreViewModel(string userId);

        GenreImage RedirectGenreImage(int id);
    }
}
