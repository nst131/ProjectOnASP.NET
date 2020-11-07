using PresentationYandexMusic.Models.HomeModels;

namespace PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces
{
    public interface IHomePresentationService : IBasePresentationService
    {
        MainViewModel GetMainViewModel();
    }
}
