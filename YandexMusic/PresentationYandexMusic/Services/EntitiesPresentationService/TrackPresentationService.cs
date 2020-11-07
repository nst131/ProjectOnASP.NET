using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Models.TrackModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }

        public TrackImage RedirecttrackImage(int id)
        {
            return trackDomainService.RedirectTrackImage(id);
        }

        public TrackGenreViewModel GetTrackGenreViewModel(int id)
        {
            return new TrackGenreViewModel()
            {
                LikedTrack = trackDomainService.GetLikedTracksWithSinger(),
                Tracks = trackDomainService.GetTrackGenreByGenreId(id)
            };
        }
    }
}