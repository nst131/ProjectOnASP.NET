using DomainYandexMusic.Entities;
using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class NoveltyDomainService : INoveltyDomainService
    {
        private readonly INoveltyRepository noveltyRepository;

        public NoveltyDomainService(INoveltyRepository noveltyRepository)
        {
            this.noveltyRepository = noveltyRepository;
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
    }
}
