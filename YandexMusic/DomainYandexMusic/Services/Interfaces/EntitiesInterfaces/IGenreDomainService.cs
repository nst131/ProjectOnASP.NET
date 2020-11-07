using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IGenreDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Genre genre);
        int GetFirstGenreId();
        Genre GetGenreById(int id);
        List<Genre> GetListGenre();
        bool IsExistAlbum(int id);
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueGenre(string genreName);
        GenreImage RedirectGenreImage(int id);
        int SaveChanges();
    }
}
