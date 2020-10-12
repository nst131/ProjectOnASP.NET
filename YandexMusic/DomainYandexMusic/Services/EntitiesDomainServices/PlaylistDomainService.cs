using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class PlaylistDomainService : CheckJPG, IPlaylistDomainService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IUnitOfWork unitOfWork;

        public PlaylistDomainService(IPlaylistRepository playlistRepository,IUnitOfWork unitOfWork)
        {
            this.playlistRepository = playlistRepository;
            this.unitOfWork = unitOfWork;
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
            return CheckingJpg(file);
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
    }
}
