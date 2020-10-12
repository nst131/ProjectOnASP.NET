using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class NoveltyRepository : BaseRepository<Novelty>, INoveltyRepository
    {
        public NoveltyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Novelty> GetListNovelty()
        {
            return GetQueryable().ToList();
        }
    }
}
