using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IAlbumDomainService : IBaseDomainService
    {
        void DeleteAlbum(int id);
        DbEntityEntry Entry(Album album);
        Album GetAlbumById(int id);
        Album GetAlbumWithTracks(int id);
        List<Album> GetAlbumsWithTracksBySingerId(int id);
        List<Album> GetListAlbums();
        bool IsExistAlbum(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueAlbum(string albumName);
        AlbumImage RedirectAlbumImage(int id);
        int SaveChanges();
        Album GetAlbumWithImage(int id);
        bool EditIsUniqueAlbum(int id, string albumName);
        Album GetAlbumWithTracksAndSinger(int id);
        int AmountTrackInAlbumByAlbumId(int id);
        List<Album> GetAlbumsWithSingerByQuantityAlbums(int numberAlbums);
    }
}
