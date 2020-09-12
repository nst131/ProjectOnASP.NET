using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class PopularDomainService : IPopularDomainService
    {
        private readonly IPopularRepository popularRepository;

        public PopularDomainService(IPopularRepository popularRepository)
        {
            this.popularRepository = popularRepository;
        }
    }
}
