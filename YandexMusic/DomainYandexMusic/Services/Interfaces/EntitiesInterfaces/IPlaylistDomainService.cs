using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IPlaylistDomainService : IBaseDomainService
    {
        void CreatePlaylistAndUserId(string playlistName, ApplicationUser user);
        void DeletePlaylist(int id);
        DbEntityEntry Entry(Playlist playlist);
        Dictionary<int, string> GetDictionaryPlaylist();
        List<Playlist> GetListPlaylist();
        Playlist GetPlaylistById(int id);
        bool IsExistPlaylist(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniquePlaylist(string playlistName);
        PlaylistImage RedirectPlaylistImage(int id);
        int SaveChanges();
    }
}
