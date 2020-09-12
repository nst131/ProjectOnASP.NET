using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}