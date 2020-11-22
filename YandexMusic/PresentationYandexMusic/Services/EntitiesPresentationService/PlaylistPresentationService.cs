using System.Collections.Generic;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class PlaylistPresentationService : IPlaylistPresentationService
    {
        private readonly IUserDomainService userDomain;

        public PlaylistPresentationService(IUserDomainService userDomain)
        {
            this.userDomain = userDomain;
        }

        public List<Track> GetTracksInPlaylistBeloved(string userId)
        {
            return userDomain.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);
        }

        public void AddTrackInPlaylistBeloved(string userId, int trackId)
        {
            userDomain.AddTrackInPlaylistUser(userId, KindPlaylist.Beloved, trackId);
        }

        public void DeleteTrackInPlaylistBeloved(string userId, int trackId)
        {
            userDomain.DeleteTrackInPlaylistUser(userId, KindPlaylist.Beloved, trackId);
        }
    }
}