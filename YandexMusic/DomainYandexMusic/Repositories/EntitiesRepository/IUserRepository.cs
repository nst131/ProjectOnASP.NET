using DomainYandexMusic.Entities;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        Playlist GetPlaylistWithTracksByUserIdAndPlaylistName(string userId, string playlistName);
        Playlist GetPlaylistBelovedWithTracksByUserIdAndPlaylistName(string userId);
        ApplicationUser GetUserById(string id);
    }
}
