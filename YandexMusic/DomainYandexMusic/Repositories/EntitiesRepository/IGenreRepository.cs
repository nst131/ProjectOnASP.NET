using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        int GetFirstGenreId();
        Genre GetGenreById(int id);
        Genre GetGenreWithImage(int id);
        List<Genre> GetListGenre();
        bool IsExistGenre(int id);
        bool IsUniqueGenre(string genreName);
    }
}
