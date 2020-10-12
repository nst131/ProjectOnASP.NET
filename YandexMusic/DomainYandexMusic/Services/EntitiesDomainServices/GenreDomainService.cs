using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class GenreDomainService : CheckJPG, IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenreDomainService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
        }

        public DbEntityEntry Entry(Genre genre)
        {
            return unitOfWork.Entry<Genre>(genre);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public bool IsUniqueGenre(string genreName)
        {
            return genreRepository.IsUniqueGenre(genreName);
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return CheckingJpg(file);
        }

        public List<Genre> GetListGenre()
        {
            return genreRepository.GetListGenre();
        }
    }
}
