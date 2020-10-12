using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class SingerDomainService : CheckJPG, ISingerDomainService
    {
        private readonly ISingerRepository singerRepository;
        private readonly IUnitOfWork unitOfWork;

        public SingerDomainService(ISingerRepository singerRepository,IUnitOfWork unitOfWork)
        {
            this.singerRepository = singerRepository;
            this.unitOfWork = unitOfWork;
        }

        public DbEntityEntry Entry(Singer singer)
        {
            return unitOfWork.Entry<Singer>(singer);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public List<Singer> GetListSingers()
        {
            return singerRepository.GetListSingers();
        }

        public bool IsExistSinger(int id)
        {
            return singerRepository.IsExistSinger(id);
        }

        public Singer GetSingerById(int id)
        {
            return singerRepository.GetSingerById(id);
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return CheckingJpg(file);
        }

        public bool IsUniqueSinger(string singerName)
        {
            return singerRepository.IsUniqueSinger(singerName);
        }
    }
}
