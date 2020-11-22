using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IUserDomainService : IBaseDomainService
    {
        void AddTrackInPlaylistUser(string userId, string playlistName, int trackId);
        void DeleteTrackInPlaylistUser(string userId, string playlistName, int trackId);
        List<Track> GetTracksInPlaylistBelovedByUserIdAndPlaylistName(string userId, string playlistName);
        List<Track> GetTracksInPlaylistByUserIdAndPlaylistName(string userId, string playlistName);
    }
}
