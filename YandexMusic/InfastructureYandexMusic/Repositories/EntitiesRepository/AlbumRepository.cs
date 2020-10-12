using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.UnitOfWork;
using System.Collections.Generic;
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
    }
}
