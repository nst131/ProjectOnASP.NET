using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class AlbumDomainService : IAlbumDomainService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly IAlbumRepository albumRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckFile checkFile;

        public AlbumDomainService(IAlbumRepository albumRepository, 
            IUnitOfWork unitOfWork, ICheckFile checkFile, ITrackDomainService trackDomainService)
        {
            this.albumRepository = albumRepository;
            this.unitOfWork = unitOfWork;
            this.checkFile = checkFile;
            this.trackDomainService = trackDomainService;
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
            if(file != null)
            {
                return checkFile.CheckJpg(file);
            }

            return true;
        }

        public bool IsUniqueAlbum(string albumName)
        {
            return albumRepository.IsUniqueAlbum(albumName);
        }

        public List<Album> GetListAlbums()
        {
            return albumRepository.GetListAlbums();
        }

        public Album GetAlbumById(int id)
        {
            return albumRepository.GetAlbumById(id);
        }

        public bool IsExistAlbum(int id)
        {
            return albumRepository.IsExistAlbum(id);
        }

        public Album GetAlbumWithImage(int id)
        {
            return albumRepository.GetAlbumWithImage(id);
        }

        public AlbumImage RedirectAlbumImage(int id)
        {
            return albumRepository.GetAlbumWithImage(id).AlbumImage;
        }

        public void DeleteAlbum(int id)
        {
            unitOfWork.Entry<Album>(GetAlbumById(id)).State = EntityState.Deleted;
            unitOfWork.SaveChanges();
        }

        public Album GetAlbumWithTracks(int id)
        {
            return albumRepository.GetAlbumWithTracks(id);
        }

        public List<Album> GetAlbumsWithTracksBySingerId(int id)
        {
            return albumRepository.GetAlbumsWithTracksBySingerId(id);
        }

        public bool EditIsUniqueAlbum(int id, string albumName)
        {
            return albumRepository.EditIsUniqueAlbum(id, albumName);
        }

        public Album GetAlbumWithTracksAndSinger(int id)    
        {
            Album album = albumRepository.GetAlbumWithTracksAndSinger(id);
            album.Tracks.ToList().ForEach(x => x.TrackFile = trackDomainService.GetTrackFileById(x.Id));

            return album;
        }

        public int AmountTrackInAlbumByAlbumId(int id)
        {
            return albumRepository.GetAlbumWithTracks(id).Tracks.ToList().Count();
        }

        public List<Album> GetAlbumsWithSingerByQuantityAlbums(int numberAlbums)
        {
            return albumRepository.GetRandomAlbumsWithSingerByQuantityAlbums(numberAlbums);
        }
    }
}
