using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Genre GetGenreById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistGenre(int id)
        {
            return GetQueryable()
                .Any(x => x.Id == id);
        }

        public int GetFirstGenreId()
        {
            return GetQueryable()
                .FirstOrDefault().Id;
        }

        public Genre GetGenreWithImage(int id)
        {
            return GetQueryable()
                .Include(x => x.GenreImage)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
