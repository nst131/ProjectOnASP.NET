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
        List<Singer> GetListSingers();
        Singer GetSingerById(int id);
        bool IsExistSinger(int id);
        bool IsUniqueSinger(string singerName);
    }
}
