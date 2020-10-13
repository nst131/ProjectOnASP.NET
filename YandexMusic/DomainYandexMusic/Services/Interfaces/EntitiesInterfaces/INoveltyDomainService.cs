using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface INoveltyDomainService : IBaseDomainService
    {
        Dictionary<int, string> GetDictionaryNovelty();
        Novelty GetNoveltyById(int id);
    }
}
