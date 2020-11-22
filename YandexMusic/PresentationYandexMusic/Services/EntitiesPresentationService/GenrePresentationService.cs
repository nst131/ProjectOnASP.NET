using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Models.GenreModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class GenrePresentationService : IGenrePresentationService
    {
        private readonly IGenreDomainService genreDomainService;
        private readonly IUserDomainService userDomainService;

        public GenrePresentationService(IGenreDomainService genreDomainService, IUserDomainService userDomainService)
        {
            this.genreDomainService = genreDomainService;
            this.userDomainService = userDomainService;
        }

        public GenreImage RedirectGenreImage(int id)
        {
            return genreDomainService.RedirectGenreImage(id);
        }

        public GenreViewModel GetGenreViewModel(string userId)
        {
            return new GenreViewModel()
            {
                LikedTracks = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved),
                Genres = genreDomainService.GetListGenre()
            };
        }
    }
}