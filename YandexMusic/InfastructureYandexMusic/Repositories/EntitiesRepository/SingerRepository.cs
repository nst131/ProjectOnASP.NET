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

        public Singer GetSingerWithImage(int id)
        {
            return GetQueryable()
                .Include(x => x.SingerImage)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<int> GetAlbumsIdBySingerId(int id)
        {
            List<int> albumsId = new List<int>();

            GetQueryable()
                .Include(x => x.Albums)
                .FirstOrDefault(x => x.Id == id).Albums
                .ToList().ForEach(x => albumsId.Add(x.Id));

            return albumsId;
        }

        public List<Singer> GetSingersWithAlbums()
        {
            return GetQueryable()
                .Include(x => x.Albums)
                .ToList();
        }

        public bool EditIsUniqueSinger(int id, string singerName)
        {
            return !GetQueryable().Any(x => x.Name == singerName && x.Id != id);
        }

        public int AmountTracksInSinger(int id)
        {
            return Get(id).Tracks.Count();
        }

        public int AmountAlbumsInSinger(int id)
        {
            return Get(id).Albums.Count();
        }
    }
}
