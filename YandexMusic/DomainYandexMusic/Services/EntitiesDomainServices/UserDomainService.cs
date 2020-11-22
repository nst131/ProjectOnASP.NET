using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository userRepository;
        private readonly ITrackRepository trackRepository;
        private readonly IPlaylistDomainService playlistDomain;
        private readonly IUnitOfWork unitOfWork;

        public UserDomainService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ITrackRepository trackRepository,
            IPlaylistDomainService playlistDomain)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            this.trackRepository = trackRepository;
            this.playlistDomain = playlistDomain;
        }

        public DbEntityEntry Entry(ApplicationUser user)
        {
            return unitOfWork.Entry<ApplicationUser>(user);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public List<Track> GetTracksInPlaylistBelovedByUserIdAndPlaylistName(string userId, string playlistName)
        {
            var playlist = userRepository.GetPlaylistBelovedWithTracksByUserIdAndPlaylistName(userId);

            if (playlist == null)
            {
                playlistDomain.CreatePlaylistAndUserId(playlistName, userRepository.GetUserById(userId));

                return userRepository.GetPlaylistBelovedWithTracksByUserIdAndPlaylistName(userId).Tracks.ToList();
            }

            return playlist.Tracks.ToList();
        }

        public void AddTrackInPlaylistUser(string userId, string playlistName, int trackId)
        {
            var playlist = userRepository.GetPlaylistWithTracksByUserIdAndPlaylistName(userId, playlistName);

            if (playlist == null)
            {
                playlistDomain.CreatePlaylistAndUserId(playlistName, userRepository.GetUserById(userId));
            }

            var track = trackRepository.GetTrackById(trackId);

            if(!playlist.Tracks.Contains(track))
            {
                playlist.Tracks.Add(track);
                playlistDomain.SaveChanges();
            }
        }

        public void DeleteTrackInPlaylistUser(string userId, string playlistName, int trackId)
        {
            var playlist = userRepository.GetPlaylistWithTracksByUserIdAndPlaylistName(userId, playlistName);
            var track = trackRepository.GetTrackById(trackId);

            if (playlist.Tracks.Contains(track))
            {
                playlist.Tracks.Remove(track);
                playlistDomain.SaveChanges();
            }
        }

        public List<Track> GetTracksInPlaylistByUserIdAndPlaylistName(string userId, string playlistName)
        {
            var playlist = userRepository.GetPlaylistWithTracksByUserIdAndPlaylistName(userId, playlistName);

            if (playlist == null)
            {
                playlistDomain.CreatePlaylistAndUserId(playlistName, userRepository.GetUserById(userId));
            }

            return userRepository.GetPlaylistWithTracksByUserIdAndPlaylistName(userId, playlistName).Tracks.ToList();
        }
    }
}
