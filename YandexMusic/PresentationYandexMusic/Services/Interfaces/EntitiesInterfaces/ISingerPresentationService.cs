using DomainYandexMusic.Entities;
using PresentationYandexMusic.Models.SingerModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface ISingerPresentationService : IBasePresentationService
    {
        SingerImage RedirectSingerImage(int id);
        SingerViewModel GetSingersViewModel();
        SingerDetailViewModel GetSingerDetailViewModel(int id);
    }
}
