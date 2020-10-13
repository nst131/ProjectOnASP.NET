using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ISingerDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Singer singer);
        AlbumNames GetAlbumNamesBySingerId(int id);
        int GetFirstSingerId();
        List<Singer> GetListSingers();
        Singer GetSingerById(int id);
        Singer GetSingerByIdWithAlbums(int id);
        bool IsExistSinger(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueSinger(string singerName);
        int SaveChanges();
    }
}
