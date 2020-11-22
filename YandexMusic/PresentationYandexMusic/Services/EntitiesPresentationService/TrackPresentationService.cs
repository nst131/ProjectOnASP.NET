using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Models.TrackModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly IUserDomainService userDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService, IUserDomainService userDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.userDomainService = userDomainService;
        }

        public TrackImage RedirecttrackImage(int id)
        {
            return trackDomainService.RedirectTrackImage(id);
        }

        public TrackGenreViewModel GetTrackGenreViewModel(int id, string userId)
        {
            var likeTrack = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);
            var track = trackDomainService.GetTrackWithSingerAndTrackFileByGenreId(id);

            track.ForEach(x =>
            {
                if (likeTrack.Contains(x))
                {
                    x.Like = true;
                }
            });

            return new TrackGenreViewModel()
            {
                LikedTrack = likeTrack,
                Tracks = track
            };
        }

        public LikedTrackViewModel GetLikedTrackView(string userId)
        {
            var likeTrack = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);
            likeTrack.ForEach(x => x.Like = true);

            return new LikedTrackViewModel
            {
                LikedTrack = likeTrack
            };
        }
    }
}