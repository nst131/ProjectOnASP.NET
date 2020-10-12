using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class PopularRepository : BaseRepository<Popular>, IPopularRepository
    {
        public PopularRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public List<Popular> GetListPopular()
        {
            return GetQueryable().ToList();
        }
    }
}
