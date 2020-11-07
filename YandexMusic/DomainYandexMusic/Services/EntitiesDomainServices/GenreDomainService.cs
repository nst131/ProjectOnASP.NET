using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class GenreDomainService : IGenreDomainService
    {
        private readonly IGenreRepository genreRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckFile checkFile;

        public GenreDomainService(IGenreRepository genreRepository,
            IUnitOfWork unitOfWork, ICheckFile checkFile)
        {
            this.genreRepository = genreRepository;
            this.unitOfWork = unitOfWork;
            this.checkFile = checkFile;
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
            return checkFile.CheckJpg(file);
        }

        public List<Genre> GetListGenre()
        {
            return genreRepository.GetListGenre();
        }

        public Genre GetGenreById(int id)
        {
            return genreRepository.GetGenreById(id);
        }

        public bool IsExistAlbum(int id)
        {
            return genreRepository.IsExistGenre(id);
        }

        public int GetFirstGenreId()
        {
            return genreRepository.GetFirstGenreId();
        }

        public GenreImage RedirectGenreImage(int id)
        {
            return genreRepository.GetGenreWithImage(id).GenreImage;
        }
    }
}
