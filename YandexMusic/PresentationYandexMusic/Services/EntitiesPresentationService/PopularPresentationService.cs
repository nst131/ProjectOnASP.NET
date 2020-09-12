using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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