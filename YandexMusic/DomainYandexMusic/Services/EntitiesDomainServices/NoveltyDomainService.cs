using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class NoveltyDomainService : INoveltyDomainService
    {
        private readonly INoveltyRepository noveltyRepository;
        private readonly ITrackDomainService trackDomainService;

        public NoveltyDomainService(INoveltyRepository noveltyRepository, ITrackDomainService trackDomainService)
        {
            this.noveltyRepository = noveltyRepository;
            this.trackDomainService = trackDomainService;
        }

        public List<Novelty> GetListNovelty()
        {
            return noveltyRepository.GetListNovelty();
        }

        public Dictionary<int, string> GetDictionaryNovelty()
        {
            Dictionary<int, string> vs = new Dictionary<int, string>();

            GetListNovelty().ForEach(x => vs.Add(x.Id, x.Name));

            return vs;
        }

        public Novelty GetNoveltyById(int id)
        {
            return noveltyRepository.GetNoveltyById(id);
        }

        public List<Track> GetNoveltyTracksByQuantityTracks(int numberTracks)
        {
            List<Track> vs = new List<Track>();
            List<int> randomTracksId = noveltyRepository.GetRandomNoveltyTracksIdByQuantityTracks(numberTracks);
            randomTracksId.ForEach(x => vs.Add(trackDomainService.GetTrackWithSingerById(x)));

            return vs;
        }
    }
}
