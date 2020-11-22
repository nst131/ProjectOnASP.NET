using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class PopularDomainService : IPopularDomainService
    {
        private readonly IPopularRepository popularRepository;

        public PopularDomainService(IPopularRepository popularRepository)
        {
            this.popularRepository = popularRepository;
        }

        public List<Popular> GetListPopular()
        {
            return popularRepository.GetListPopular();
        }

        public Dictionary<int, string> GetDictionaryPopular()
        {
            Dictionary<int, string> vs = new Dictionary<int, string>();

            GetListPopular().ForEach(x => vs.Add(x.Id, x.Name));

            return vs;
        }

        public Popular GetPopularById(int id)
        {
            return popularRepository.GetPopularById(id);
        }

        public List<Track> GetPopularTracksByQuantityTracks(int numberTracks)
        {
            return popularRepository.GetRandomPopularsTracksIdByQuantityTracks(numberTracks);
        }
    }
}
