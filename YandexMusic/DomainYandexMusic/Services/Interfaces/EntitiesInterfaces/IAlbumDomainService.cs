using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IAlbumDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Album album);
        Album GetAlbumById(int id);
        List<Album> GetListAlbums();
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueAlbum(string albumName);
        int SaveChanges();
    }
}
