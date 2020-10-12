using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class AlbumDomainService : CheckJPG, IAlbumDomainService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;

        public AlbumDomainService(IAlbumRepository albumRepository, IUnitOfWork unitOfWork)
        {
            this.albumRepository = albumRepository;
            this.unitOfWork = unitOfWork;
        }

        public DbEntityEntry Entry(Album album)
        {
            return unitOfWork.Entry<Album>(album);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return CheckingJpg(file);
        }

        public bool IsUniqueAlbum(string albumName)
        {
            return albumRepository.IsUniqueAlbum(albumName);
        }

        public List<Album> GetListAlbums()
        {
            return albumRepository.GetListAlbums();
        }
    }
}
