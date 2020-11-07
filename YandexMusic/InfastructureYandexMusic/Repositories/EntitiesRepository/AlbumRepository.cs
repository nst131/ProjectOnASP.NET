using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public bool IsUniqueAlbum(string albumName)
        {
            return !GetQueryable().Any(x => x.Name == albumName);
        }

        public List<Album> GetListAlbums()
        {
            return GetQueryable().ToList();
        }

        public Album GetAlbumById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistAlbum(int id)
        {
            return GetQueryable()
                .Any(x => x.Id == id);
        }

        public Album GetAlbumWithImage(int id)
        {
            return GetQueryable()
                .Include(x => x.AlbumImage)
                .FirstOrDefault(x => x.Id == id);
        }

        public Album GetAlbumWithTracks(int id)
        {
            return GetQueryable()
                .Include(x => x.Tracks)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Album> GetAlbumsWithTracksBySingerId(int id)
        {
            return GetQueryable()
                .Where(x => x.SingerId == id)
                .Include(x => x.Tracks)
                .ToList();
        }

        public bool EditIsUniqueAlbum(int id, string albumName)
        {
            return !GetQueryable().Any(x => x.Name == albumName && x.Id != id);
        }

        public Album GetAlbumWithTracksAndSinger(int id)
        {
            return GetQueryable()
                .Include(x => x.Singer)
                .Include(x => x.Tracks)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Album> GetRandomAlbumsWithSingerByQuantityAlbums(int numberAlbums)
        {
            List<int> albumsId = GetRandomAlbumId(numberAlbums);
            List<Album> vs = new List<Album>();
            albumsId.ForEach(x => vs.Add(GetAlbumWithSingerByAlbumId(x)));

            return vs;
        }

        private Album GetAlbumWithSingerByAlbumId(int id)
        {
            return GetQueryable().Include(x => x.Singer).FirstOrDefault(x => x.Id == id);
        }

        private List<int> GetAllAlbumsId()
        {
            return GetQueryable().Select(x => x.Id).ToList();
        }

        private List<int> GetRandomAlbumId(int numberAlbums)
        {
            List<int> vs = new List<int>();
            Random random = new Random();
            List<int> albumsId = GetAllAlbumsId();

            if (albumsId.Count >= numberAlbums)
            {
                for (int i = 0; i < numberAlbums; i++)
                {
                    var elem = albumsId[random.Next(albumsId.Count)];
                    vs.Add(elem);
                    albumsId.Remove(elem);
                }

                return vs;
            }

            for (int i = 0; i < numberAlbums; i++)
            {
                vs.Add(albumsId[random.Next(albumsId.Count)]);
            }

            return vs;
        }
    }
}
