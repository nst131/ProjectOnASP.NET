using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class AlbumPresentationService : IAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;

        public AlbumPresentationService(IAlbumDomainService albumDomainService)
        {
            this.albumDomainService = albumDomainService;
        }
    }
}