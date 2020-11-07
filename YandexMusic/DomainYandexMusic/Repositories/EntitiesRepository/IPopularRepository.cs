using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace DomainYandexMusic.Repositories.EntitiesRepository
{
    public interface IPopularRepository : IBaseRepository<Popular>
    {
        List<Popular> GetListPopular();
        Popular GetPopularById(int id);
        List<int> GetRandomPopularTracksIdByQuantityTracks(int numberTracks);
    }
}
