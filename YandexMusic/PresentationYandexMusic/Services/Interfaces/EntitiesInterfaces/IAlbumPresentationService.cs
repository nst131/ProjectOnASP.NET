using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.AlbumModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IAlbumPresentationService : IBasePresentationService
    {
        AlbumDetailViewModel GetAlbumDetailViewModel(int id, string userId);

        AlbumImage RedirectAlbumImage(int id);
    }
}
