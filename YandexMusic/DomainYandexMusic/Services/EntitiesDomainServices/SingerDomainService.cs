using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class SingerDomainService : ISingerDomainService
    {
        private readonly ISingerRepository singerRepository;

        public SingerDomainService(ISingerRepository singerRepository)
        {
            this.singerRepository = singerRepository;
        }
    }
}
