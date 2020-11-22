using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.SingerModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ISingerPresentationService : IBasePresentationService
    {
        SingerDetailViewModel GetSingerDetailViewModel(int id, string userId);

        SingerViewModel GetSingersViewModel(string userId);

        SingerImage RedirectSingerImage(int id);
    }
}
