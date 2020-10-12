using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class GenrePresentationService : IGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;

        public GenrePresentationService(IGenreDomainService genreDomainService)
        {
            this.genreDomainService = genreDomainService;
        }
    }
}