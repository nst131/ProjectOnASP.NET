using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface ISingerRepository : IBaseRepository<Singer>
    {
        int AmountAlbumsInSinger(int id);
        int AmountTracksInSinger(int id);
        bool EditIsUniqueSinger(int id, string singerName);
        List<int> GetAlbumsIdBySingerId(int id);
        int GetFirstSingerId();
        List<Singer> GetListSingers();
        Singer GetSingerById(int id);
        Singer GetSingerByIdWithAlbums(int id);
        List<Singer> GetSingersWithAlbums();
        Singer GetSingerWithImage(int id);
        bool IsExistSinger(int id);
        bool IsUniqueSinger(string singerName);
    }
}
