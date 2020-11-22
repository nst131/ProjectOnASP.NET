using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using InfastructureYandexMusic.Models;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Playlist GetPlaylistBelovedWithTracksByUserIdAndPlaylistName(string id)
        {
            try
            {
                return GetQueryable()
                    .Include(x => x.Playlists)
                    .Include(x => x.Playlists.Select(y => y.Tracks))
                    .Include(x => x.Playlists.Select(y => y.Tracks.Select(z => z.Singer)))
                    .Include(x => x.Playlists.Select(y => y.Tracks.Select(z => z.TrackFile)))
                    .Single(x => x.Id.Equals(id)).Playlists.Single(y => y.Name.Equals(KindPlaylist.Beloved));
            }
            catch
            {
                return null;
            }
        }

        public ApplicationUser GetUserById(string id)
        {
            return GetQueryable()
                .SingleOrDefault(x => x.Id.Equals(id));
        }

        public Playlist GetPlaylistWithTracksByUserIdAndPlaylistName(string userId, string playlistName)
        {
            Playlist playlist;

            try
            {
                playlist = GetQueryable()
                    .Include(x => x.Playlists)
                    .Include(x => x.Playlists.Select(y => y.Tracks))
                    .Single(y => y.Id.Equals(userId))
                    .Playlists.Single(z => z.Name.Equals(playlistName));
            }
            catch
            {
                return null;
            }

            return playlist;
        }


    }
}
