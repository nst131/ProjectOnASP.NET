using DomainYandexMusic.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IPopularRepository : IBaseRepository<Popular>
    {
        List<Popular> GetListPopular();
        Popular GetPopularById(int id);
        List<Track> GetRandomPopularsTracksIdByQuantityTracks(int numberTracks);
    }
}
