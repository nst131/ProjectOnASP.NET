using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class PlaylistPresentationService : IPlaylistPresentationService
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public PlaylistPresentationService(IPlaylistDomainService playlistDomainService)
        {
            this.playlistDomainService = playlistDomainService;
        }
    }
}