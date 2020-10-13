using DomainYandexMusic.Entities;
using System.Collections.Generic;

namespace DomainYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IPopularDomainService : IBaseDomainService
    {
        Dictionary<int, string> GetDictionaryPopular();
        Popular GetPopularById(int id);
    }
}
