using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Models.SingerModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class SingerPresentationService : ISingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;
        private readonly ITrackDomainService trackDomainService;
        private readonly IUserDomainService userDomainService;

        public SingerPresentationService(
            ISingerDomainService singerDomainService,
            ITrackDomainService trackDomainService,
            IUserDomainService userDomainService)
        {
            this.singerDomainService = singerDomainService;
            this.trackDomainService = trackDomainService;
            this.userDomainService = userDomainService;
        }

        public SingerViewModel GetSingersViewModel(string userId)
        {
            return new SingerViewModel()
            {
                Singers = singerDomainService.GetListSingers(),
                LikedTracks = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved)
            };
        }

        public SingerImage RedirectSingerImage(int id)
        {
            return singerDomainService.RedirectSingerImage(id);
        }

        public SingerDetailViewModel GetSingerDetailViewModel(int id, string userId)
        {
            var singer = singerDomainService.GetSingerByIdWithAlbums(id);
            singer.Tracks = trackDomainService.GetPopularTracksWithAlbumsAndTrackFileBySingerId(id);
            var likeTrack = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);

            foreach (var item in singer.Tracks)
            {
                if (likeTrack.Contains(item))
                {
                    item.Like = true;
                }
            }

            return new SingerDetailViewModel()
            {
                Singer = singer,
                SingerGenre = trackDomainService.GetGenreBySingerId(id),
                LikedTracks = likeTrack,
                AmountAlbums = singerDomainService.AmountAlbumsInSinger(id),
                AmountTracks = singerDomainService.AmountTracksInSinger(id)
            };
        }
    }
}