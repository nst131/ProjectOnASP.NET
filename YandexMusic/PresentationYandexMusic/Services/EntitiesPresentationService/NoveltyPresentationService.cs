using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class NoveltyPresentationService : INoveltyPresentationService
    {
        private readonly INoveltyDomainService noveltyDomainService;

        public NoveltyPresentationService(INoveltyDomainService noveltyDomainService)
        {
            this.noveltyDomainService = noveltyDomainService;
        }
    }
}
