using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IGenreDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Genre genre);
        List<Genre> GetListGenre();
        bool IsJpg(HttpPostedFileBase file);
        bool IsUniqueGenre(string genreName);
        int SaveChanges();
    }
}
