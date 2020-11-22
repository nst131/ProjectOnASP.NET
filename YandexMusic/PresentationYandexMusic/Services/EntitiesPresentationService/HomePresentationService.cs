using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Models.HomeModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class HomePresentationService : IHomePresentationService
    {
        private readonly IAlbumDomainService albumDomain;
        private readonly IPopularDomainService popularDomain;
        private readonly INoveltyDomainService noveltyDomain;
        private readonly IUserDomainService userDomain;

        public HomePresentationService(
            IAlbumDomainService albumDomain,
            IPopularDomainService popularDomain,
            INoveltyDomainService noveltyDomain,
            IUserDomainService userDomain)
        {
            this.albumDomain = albumDomain;
            this.popularDomain = popularDomain;
            this.noveltyDomain = noveltyDomain;
            this.userDomain = userDomain;
        }

        public MainViewModel GetMainViewModel(string userId)
        {
            var popularTracks = popularDomain.GetPopularTracksByQuantityTracks(9); // number PopularTracks
            var noveltyTracks = noveltyDomain.GetNoveltyTracksByQuantityTracks(8); // number NoveltyTracks
            var albums = albumDomain.GetAlbumsWithSingerByQuantityAlbums(7); // number AlbumsTracks

            var likedTracks = userDomain.GetTracksInPlaylistByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);
            if (likedTracks != null)
            {
                popularTracks.ForEach(x =>
                {
                    if (likedTracks.Contains(x))
                    {
                        x.Like = true;
                    }
                });

                noveltyTracks.ForEach(x =>
                {
                    if (likedTracks.Contains(x))
                    {
                        x.Like = true;
                    }
                });
            }

            return new MainViewModel()
            {
                PopularTracks = popularTracks,
                NoveltyTracks = noveltyTracks,
                Albums = albums
            };
        }
    }
}