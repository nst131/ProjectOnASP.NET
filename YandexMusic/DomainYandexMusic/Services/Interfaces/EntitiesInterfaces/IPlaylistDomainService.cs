using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IPlaylistDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Playlist playlist);
        Dictionary<int, string> GetDictionaryPlaylist();
        List<Playlist> GetListPlaylist();
        Playlist GetPlaylistById(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniquePlaylist(string playlistName);
        int SaveChanges();
    }
}
