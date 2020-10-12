using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class SingerPresentationService : ISingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;

        public SingerPresentationService(ISingerDomainService singerDomainService)
        {
            this.singerDomainService = singerDomainService;
        }
    }
}