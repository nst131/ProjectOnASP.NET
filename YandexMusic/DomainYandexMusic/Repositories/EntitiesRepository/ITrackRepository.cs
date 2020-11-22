using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface ITrackRepository : IBaseRepository<Track>
    {
        bool CreateTrackIsUnique(string trackName);
        void DeleteTrackFileByName(string name);
        bool EditTrackIsUnique(int id, string trackName);
        List<Track> GetPopularTracksWithAlbumsAndTrackFileBySingerId(int id);
        Track GetTrackById(int id);
        Track GetTrackByName(string name);
        List<Track> GetTrackWithSingerAndTrackFileByGenreId(int id);
        List<Track> GetTracksWithTrackFileByAlbumId(int id);
        Track GetTrackWithGenreBySingerId(int id);
        Track GetTrackWithImage(int id);
        Track GetTrackWithImageAndFileTrack(int id);
        Track GetTrackWithSingerAndTrackFileById(int id);
        bool IsExistTrack(int id);
        Track GetTrackWithTrackFileById(int id);
    }
}
