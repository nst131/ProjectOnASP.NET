using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.TrackModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ITrackPresentationService : IBasePresentationService
    {
        LikedTrackViewModel GetLikedTrackView(string userId);

        TrackGenreViewModel GetTrackGenreViewModel(int id, string userId);

        TrackImage RedirecttrackImage(int id);
    }
}
