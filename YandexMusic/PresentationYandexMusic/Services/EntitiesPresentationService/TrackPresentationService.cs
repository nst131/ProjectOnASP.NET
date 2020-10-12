using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class TrackPresentationService : ITrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;

        public TrackPresentationService(ITrackDomainService trackDomainService)
        {
            this.trackDomainService = trackDomainService;
        }
    }
}