using System.Collections.Generic;
using DomainYandexMusic.Entities;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IPlaylistPresentationService : IBasePresentationService
    {
        void AddTrackInPlaylistBeloved(string userId, int trackId);

        void DeleteTrackInPlaylistBeloved(string userId, int trackId);

        List<Track> GetTracksInPlaylistBeloved(string userId);
    }
}
