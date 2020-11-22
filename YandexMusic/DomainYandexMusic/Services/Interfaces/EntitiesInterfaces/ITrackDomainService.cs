using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ITrackDomainService : IBaseDomainService
    {
        void DeleteTrackFileByName(string name);
        DbEntityEntry Entry(Track track);
        bool IsJpg(HttpPostedFileBase file);
        bool IsMP3(HttpPostedFileBase file);
        int SaveChanges();
        TrackImage RedirectTrackImage(int id);
        bool IsExistTrack(int id);
        Track GetTrackById(int id);
        void DeleteTrack(int id);
        List<Track> GetTracksWithTrackFileByAlbumId(int id);
        Track GetTrackWithImageAndFileTrack(int id);
        bool EditTrackIsUnique(int id, string trackName);
        bool CreateTrackIsUnique(string trackmName);
        Genre GetGenreBySingerId(int id);
        List<Track> GetPopularTracksWithAlbumsAndTrackFileBySingerId(int id);
        Track GetTrackWithSingerAndTrackFileById(int id);
        List<Track> GetTrackWithSingerAndTrackFileByGenreId(int id);
        TrackFile GetTrackFileById(int id);
    }
}
