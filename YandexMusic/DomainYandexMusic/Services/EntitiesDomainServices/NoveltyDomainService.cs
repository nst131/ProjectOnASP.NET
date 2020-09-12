using DomainYandexMusic.Repositories.EntitiesRepository;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainYandexMusic.Services.EntitiesDomainServices
{
    public class NoveltyDomainService : INoveltyDomainService
    {
        private readonly INoveltyRepository noveltyRepository;

        public NoveltyDomainService(INoveltyRepository noveltyRepository)
        {
            this.noveltyRepository = noveltyRepository;
        }
    }
}
