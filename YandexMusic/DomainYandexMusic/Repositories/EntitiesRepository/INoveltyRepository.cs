using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface INoveltyRepository : IBaseRepository<Novelty>
    {
        List<Novelty> GetListNovelty();
        Novelty GetNoveltyById(int id);
    }
}
