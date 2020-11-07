using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class TrackDomainService : ITrackDomainService
    {
        private readonly ITrackRepository trackRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckFile checkFile;

        public TrackDomainService(ITrackRepository trackRepository,
            IUnitOfWork unitOfWork, ICheckFile checkFile)
        {
            this.trackRepository = trackRepository;
            this.unitOfWork = unitOfWork;
            this.checkFile = checkFile;
        }

        public DbEntityEntry Entry(Track track)
        {
            return unitOfWork.Entry<Track>(track);
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

        public bool IsMP3(HttpPostedFileBase file)
        {
            if(file != null)
            {
                return checkFile.CheckMP3(file);
            }

            return true;
        }

        public void DeleteTrackFileByName(string name)
        {
            trackRepository.DeleteTrackFileByName(name);
        }

        public TrackImage RedirectTrackImage(int id)
        {
            return trackRepository.GetTrackWithImage(id).TrackImage;
        }

        public bool IsExistTrack(int id)
        {
            return trackRepository.IsExistTrack(id);
        }

        public Track GetTrackById(int id)
        {
            return trackRepository.GetTrackById(id);
        }

        public void DeleteTrack(int id)
        {
            Track track = GetTrackById(id);

            trackRepository.DeleteTrackFileByName(track.Name);
            unitOfWork.Entry<Track>(track).State = EntityState.Deleted;
            unitOfWork.SaveChanges();
        }

        public List<Track> GetTracksWithTrackFileByAlbumId(int id)
        {
            return trackRepository.GetTracksWithTrackFileByAlbumId(id);
        }

        public Track GetTrackWithImageAndFileTrack(int id)
        {
            return trackRepository.GetTrackWithImageAndFileTrack(id);
        }

        public bool EditTrackIsUnique(int id, string trackName)
        {
            return trackRepository.EditTrackIsUnique(id, trackName);
        }

        public bool CreateTrackIsUnique(string trackmName)
        {
            return trackRepository.CreateTrackIsUnique(trackmName);
        }

        public List<Track> GetLikedTracksWithSinger()
        {
            return trackRepository.GetLikedTracksWithSinger();
        }

        public Genre GetGenreBySingerId(int id)
        {
            return trackRepository.GetTrackWithGenreBySingerId(id).Genre;
        }

        public List<Track> GetPopularTracksWithAlbumsBySingerId(int id)
        {
            return trackRepository.GetPopularTracksWithAlbumsBySingerId(id);
        }

        public Track GetTrackWithSingerById(int id)
        {
            return trackRepository.GetTrackWithSingerById(id);
        }

        public List<Track> GetTrackGenreByGenreId(int id)
        {
            return trackRepository.GetTrackGenreByGenreId(id);
        }
    }
}
