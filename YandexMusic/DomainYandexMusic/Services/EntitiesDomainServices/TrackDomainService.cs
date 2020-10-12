using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Data.Entity.Infrastructure;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrackDomainService(ITrackRepository trackRepository, IUnitOfWork unitOfWork)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
        }

        public DbEntityEntry Entry(Track track)
        {
            return unitOfWork.Entry<Track>(track);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }
    }
}
