using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
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
    public class SingerDomainService : ISingerDomainService
    {
        private readonly ISingerRepository singerRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckFile checkFile;

        public SingerDomainService(ISingerRepository singerRepository,
            IUnitOfWork unitOfWork, ICheckFile checkFile)
        {
            this.singerRepository = singerRepository;
            this.unitOfWork = unitOfWork;
            this.checkFile = checkFile;
        }

        public DbEntityEntry Entry(Singer singer)
        {
            return unitOfWork.Entry<Singer>(singer);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public List<Singer> GetListSingers()
        {
            return singerRepository.GetListSingers();
        }

        public bool IsExistSinger(int id)
        {
            return singerRepository.IsExistSinger(id);
        }

        public Singer GetSingerById(int id)
        {
            return singerRepository.GetSingerById(id);
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            if (file != null)
            {
                return checkFile.CheckJpg(file);
            }

            return true;
        }

        public bool IsUniqueSinger(string singerName)
        {
            return singerRepository.IsUniqueSinger(singerName);
        }

        public ICollection<Album> GetAlbumsBySingerId(int id)
        {
            return GetSingerByIdWithAlbums(id).Albums;
        }

        public Singer GetSingerByIdWithAlbums(int id)
        {
            return singerRepository.GetSingerByIdWithAlbums(id);
        }

        public AlbumNames GetAlbumNamesBySingerId(int id)
        {
            Singer singer = GetSingerByIdWithAlbums(id);

            List<int> albumId = new List<int>();
            List<string> albumName = new List<string>();

            foreach (var item in singer.Albums)
            {
                albumId.Add(item.Id);
                albumName.Add(item.Name);
            }

            return new AlbumNames()
            {
                AlbumsId = albumId,
                AlbumsName = albumName
            };
        }

        public int GetFirstSingerId()
        {
            return singerRepository.GetFirstSingerId();
        }

        public Singer GetSingerWithImage(int id)
        {
            return singerRepository.GetSingerWithImage(id);
        }

        public SingerImage RedirectSingerImage(int id)
        {
            return singerRepository.GetSingerWithImage(id).SingerImage;
        }

        public void DeleteSinger(int id)
        {
            unitOfWork.Entry<Singer>(GetSingerById(id)).State = EntityState.Deleted;
            unitOfWork.SaveChanges();
        }

        public List<int> GetAlbumsIdBySingerId(int id)
        {
            return singerRepository.GetAlbumsIdBySingerId(id);
        }

        public List<Singer> GetSingersWithAlbums()
        {
            return singerRepository.GetSingersWithAlbums();
        }

        public int GetFirstAlbumIdBySingerId(int id)
        {
            return singerRepository.GetSingerByIdWithAlbums(id)
                .Albums.FirstOrDefault().Id;
        }

        public bool EditIsUniqueSinger(int id, string singerName)
        {
            return singerRepository.EditIsUniqueSinger(id, singerName);
        }

        public int AmountTracksInSinger(int id)
        {
            return singerRepository.AmountTracksInSinger(id);
        }

        public int AmountAlbumsInSinger(int id)
        {
            return singerRepository.AmountAlbumsInSinger(id);
        }
    }
}
