using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ISingerDomainService : IBaseDomainService
    {
        int AmountAlbumsInSinger(int id);
        int AmountTracksInSinger(int id);
        void DeleteSinger(int id);
        bool EditIsUniqueSinger(int id, string singerName);
        DbEntityEntry Entry(Singer singer);
        AlbumNames GetAlbumNamesBySingerId(int id);
        ICollection<Album> GetAlbumsBySingerId(int id);
        List<int> GetAlbumsIdBySingerId(int id);
        int GetFirstAlbumIdBySingerId(int id);
        int GetFirstSingerId();
        List<Singer> GetListSingers();
        Singer GetSingerById(int id);
        Singer GetSingerByIdWithAlbums(int id);
        List<Singer> GetSingersWithAlbums();
        Singer GetSingerWithImage(int id);
        bool IsExistSinger(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueSinger(string singerName);
        SingerImage RedirectSingerImage(int id);
        int SaveChanges();
    }
}
