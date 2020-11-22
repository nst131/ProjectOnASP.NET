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
    public class PlaylistDomainService : IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckFile checkFile;

        public PlaylistDomainService(IPlaylistRepository playlistRepository,
            IUnitOfWork unitOfWork, ICheckFile checkFile)
        {
            this.playlistRepository = playlistRepository;
            this.unitOfWork = unitOfWork;
            this.checkFile = checkFile;
        }

        public DbEntityEntry Entry(Playlist playlist)
        {
            return unitOfWork.Entry<Playlist>(playlist);
        }

        public int SaveChanges()
        {
            return unitOfWork.SaveChanges();
        }

        public bool IsUniquePlaylist(string playlistName)
        {
            return playlistRepository.IsUniquePlaylist(playlistName);
        }

        public bool IsJpg(HttpPostedFileBase file)
        {
            return checkFile.CheckJpg(file);
        }

        public List<Playlist> GetListPlaylist()
        {
            return playlistRepository.GetListPlaylist();
        }

        public Dictionary<int,string> GetDictionaryPlaylist()
        {
            Dictionary<int, string> vs = new Dictionary<int, string>();

            GetListPlaylist().ForEach(x => vs.Add(x.Id, x.Name));

            return vs;
        }

        public Playlist GetPlaylistById(int id)
        {
            return playlistRepository.GetPlaylistById(id);
        }

        public bool IsExistPlaylist(int id)
        {
            return playlistRepository.IsExistPlaylist(id);
        }

        public void DeletePlaylist(int id)
        {
            Entry(GetPlaylistById(id)).State = EntityState.Deleted;
            SaveChanges();
        }

        public PlaylistImage RedirectPlaylistImage(int id)
        {
            return playlistRepository.GetPlaylistWithImage(id).PlaylistImage;
        }

        public void CreatePlaylistAndUserId(string playlistName, ApplicationUser user)
        {
            var playlist = new Playlist { Name = playlistName, Users = new List<ApplicationUser> { user } };

            Entry(playlist).State = EntityState.Added;
            SaveChanges();
        }
    }
}