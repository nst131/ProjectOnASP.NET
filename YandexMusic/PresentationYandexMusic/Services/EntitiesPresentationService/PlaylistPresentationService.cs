using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class PlaylistPresentationService : IPlaylistPresentationService
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public PlaylistPresentationService(IPlaylistDomainService playlistDomainService)
        {
            this.playlistDomainService = playlistDomainService;
        }
    }
}