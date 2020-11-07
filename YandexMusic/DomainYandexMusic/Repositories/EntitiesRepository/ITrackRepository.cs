using DomainYandexMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        bool CreateTrackIsUnique(string trackName);
        void DeleteTrackFileByName(string name);
        bool EditTrackIsUnique(int id, string trackName);
        List<Track> GetLikedTracksWithSinger();
        List<Track> GetPopularTracksWithAlbumsBySingerId(int id);
        Track GetTrackById(int id);
        Track GetTrackByName(string name);
        List<Track> GetTrackGenreByGenreId(int id);
        List<Track> GetTracksWithTrackFileByAlbumId(int id);
        Track GetTrackWithGenreBySingerId(int id);
        Track GetTrackWithImage(int id);
        Track GetTrackWithImageAndFileTrack(int id);
        Track GetTrackWithSingerById(int id);
        bool IsExistTrack(int id);
    }
}
