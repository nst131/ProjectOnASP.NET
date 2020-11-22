using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace InfastructureYandexMusic.Repositories.EntitiesRepository
{
    public class TrackRepository : BaseRepository<Track>, ITrackRepository
    {
        private const string pathServerFiles = "D:/Программирование/Задачи/ProjectOnASP.NET_YandexMusic/ProjectOnASP.NET/YandexMusic/PresentationYandexMusic/ServerFiles/";

        public TrackRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public Track GetTrackByName(string name)
        {
            return GetQueryable()
                .Include(x => x.TrackFile)
                .FirstOrDefault(x => x.Name == name);
        }

        public void DeleteTrackFileByName(string name)
        {
            FileInfo file = new FileInfo(pathServerFiles + name + ".mp3");

            if (file.Exists)
            {
                file.Delete();
            }
        }

        public Track GetTrackWithImage(int id)
        {
            return GetQueryable()
                .Include(x => x.TrackImage)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistTrack(int id)
        {
            return GetQueryable()
                .Any(x => x.Id == id);
        }

        public Track GetTrackById(int id)
        {
            return GetQueryable()
                .FirstOrDefault(x => x.Id == id);
        }

        public Track GetTrackWithTrackFileById(int id)
        {
            return GetQueryable()
                .Include(x => x.TrackFile)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Track> GetTracksWithTrackFileByAlbumId(int id)
        {
            return GetQueryable()
                .Where(x => x.AlbumId == id)
                .Include(x => x.TrackFile)
                .ToList();
        }

        public Track GetTrackWithImageAndFileTrack(int id)
        {
            return GetQueryable()
                .Include(x => x.TrackImage)
                .Include(x => x.TrackFile)
                .FirstOrDefault(x => x.Id == id);
        }

        public bool EditTrackIsUnique(int id, string trackName)
        {
            return !GetQueryable().Any(x => x.Name == trackName && x.Id != id);
        }

        public bool CreateTrackIsUnique(string trackName)
        {
            return !GetQueryable().Any(x => x.Name == trackName);
        }

        public Track GetTrackWithGenreBySingerId(int id)
        {
            return GetQueryable()
                .Include(x => x.Genre)
                .FirstOrDefault(x => x.SingerId == id);
        }

        public List<Track> GetPopularTracksWithAlbumsAndTrackFileBySingerId(int id)
        {
            return GetQueryable()
                .Where(x => x.SingerId == id)
                .Include(x => x.Album)
                .Include(x => x.TrackFile)
                .ToList();
        }

        public Track GetTrackWithSingerAndTrackFileById(int id)
        {
            return GetQueryable()
                .Include(x => x.Singer)
                .Include(x => x.TrackFile)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Track> GetTrackWithSingerAndTrackFileByGenreId(int id)
        {
            return GetQueryable()
               .Where(x => x.GenreId == id)
               .Include(x => x.Singer)
               .Include(x => x.TrackFile)
               .ToList();
        }
    }
}
