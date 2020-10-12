using DomainYandexMusic.Entities;
using System.Data.Entity.Infrastructure;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ITrackDomainService : IBaseDomainService
    {
        DbEntityEntry Entry(Track track);
        int SaveChanges();
    }
}
