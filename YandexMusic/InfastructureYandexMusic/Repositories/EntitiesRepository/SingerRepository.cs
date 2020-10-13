using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class SingerRepository : BaseRepository<Singer>, ISingerRepository
    {
        public SingerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Singer> GetListSingers()
        {
            return GetQueryable()
                .ToList();
        }

        public Singer GetSingerById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistSinger(int id)
        {
            return GetQueryable()
                .Any(x => x.Id == id);
        }

        public bool IsUniqueSinger(string singerName)
        {
            return !GetQueryable()
                .Any(x => x.Name == singerName);
        }

        public Singer GetSingerByIdWithAlbums(int id)
        {
            return GetQueryable()
                .Include(x => x.Albums)
                .FirstOrDefault(x => x.Id == id);
        }

        public int GetFirstSingerId()
        {
            return GetQueryable().FirstOrDefault().Id;
        }
    }
}
