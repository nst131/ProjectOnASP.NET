using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class PopularPresentationService : IPopularPresentationService
    {
        private readonly IPopularDomainService popularDomainService;

        public PopularPresentationService(IPopularDomainService popularDomainService)
        {
            this.popularDomainService = popularDomainService;
        }
    }
}