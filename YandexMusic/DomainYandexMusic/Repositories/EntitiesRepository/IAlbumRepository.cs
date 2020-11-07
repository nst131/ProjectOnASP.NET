using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        Album GetAlbumById(int id);
        Album GetAlbumWithImage(int id);
        Album GetAlbumWithTracks(int id);
        List<Album> GetAlbumsWithTracksBySingerId(int id);
        List<Album> GetListAlbums();
        bool IsExistAlbum(int id);
        bool IsUniqueAlbum(string albumName);
        bool EditIsUniqueAlbum(int id, string albumName);
        Album GetAlbumWithTracksAndSinger(int id);
        List<Album> GetRandomAlbumsWithSingerByQuantityAlbums(int numberAlbums);
    }
}
