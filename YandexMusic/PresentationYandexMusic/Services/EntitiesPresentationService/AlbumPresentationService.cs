using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class AlbumPresentationService : IAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;

        public AlbumPresentationService(IAlbumDomainService albumDomainService)
        {
            this.albumDomainService = albumDomainService;
        }
    }
}