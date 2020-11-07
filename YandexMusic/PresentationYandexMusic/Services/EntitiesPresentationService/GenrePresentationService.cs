using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Models.GenreModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class GenrePresentationService : IGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;
        private readonly ITrackDomainService trackDomainService;

        public GenrePresentationService(IGenreDomainService genreDomainService, ITrackDomainService trackDomainService)
        {
            this.genreDomainService = genreDomainService;
            this.trackDomainService = trackDomainService;
        }

        public GenreImage RedirectGenreImage(int id)
        {
            return genreDomainService.RedirectGenreImage(id);
        }

        public GenreViewModel GetGenreViewModel()
        {
            return new GenreViewModel()
            {
                LikedTracks = trackDomainService.GetLikedTracksWithSinger(),
                Genres = genreDomainService.GetListGenre()
            };
        }
    }
}