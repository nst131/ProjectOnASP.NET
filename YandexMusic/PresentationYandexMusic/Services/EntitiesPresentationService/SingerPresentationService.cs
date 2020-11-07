using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Models.SingerModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class SingerPresentationService : ISingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;
        private readonly ITrackDomainService trackDomainService;

        public SingerPresentationService(ISingerDomainService singerDomainService,
            ITrackDomainService trackDomainService)
        {
            this.singerDomainService = singerDomainService;
            this.trackDomainService = trackDomainService;
        }

        public SingerViewModel GetSingersViewModel()
        {
            return new SingerViewModel()
            {
                Singers = singerDomainService.GetListSingers(),
                LikedTracks = trackDomainService.GetLikedTracksWithSinger()
            };
        }

        public SingerImage RedirectSingerImage(int id)
        {
            return singerDomainService.RedirectSingerImage(id);
        }

        public SingerDetailViewModel GetSingerDetailViewModel(int id)
        {
            Singer singer = singerDomainService.GetSingerByIdWithAlbums(id);
            singer.Tracks = trackDomainService.GetPopularTracksWithAlbumsBySingerId(id);

            return new SingerDetailViewModel()
            {
                Singer = singer,
                SingerGenre = trackDomainService.GetGenreBySingerId(id),
                LikedTracks = trackDomainService.GetLikedTracksWithSinger(),
                AmountAlbums = singerDomainService.AmountAlbumsInSinger(id),
                AmountTracks = singerDomainService.AmountTracksInSinger(id)
            };
        }
    }
}