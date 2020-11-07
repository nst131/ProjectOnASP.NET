using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Models.HomeModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class HomePresentationService : IHomePresentationService
    {
        private readonly IAlbumDomainService albumDomain;
        private readonly IPopularDomainService popularDomain;
        private readonly INoveltyDomainService noveltyDomain;

        public HomePresentationService(IAlbumDomainService albumDomain, IPopularDomainService popularDomain,
            INoveltyDomainService noveltyDomain)
        {
            this.albumDomain = albumDomain;
            this.popularDomain = popularDomain;
            this.noveltyDomain = noveltyDomain;
        }

        public MainViewModel GetMainViewModel()
        {
            return new MainViewModel()
            {
                PopularTracks = popularDomain.GetPopularTracksByQuantityTracks(9), // number PopularTracks 
                NoveltyTracks = noveltyDomain.GetNoveltyTracksByQuantityTracks(8), // number NoveltyTracks
                Albums = albumDomain.GetAlbumsWithSingerByQuantityAlbums(7)        // number AlbumsTracks
            };
        }
    }
}