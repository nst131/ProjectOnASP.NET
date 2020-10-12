using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public bool IsUniqueGenre(string genreName)
        {
            return !GetQueryable().Any(x => x.Name == genreName);
        }

        public List<Genre> GetListGenre()
        {
            return GetQueryable().ToList();
        }
    }
}
