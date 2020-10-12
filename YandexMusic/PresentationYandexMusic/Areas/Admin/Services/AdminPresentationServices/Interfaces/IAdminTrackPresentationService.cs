using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminTrackPresentationService : IAdminBasePresentationService
    {
        void AddTrack(TrackViewModel trackModel, HttpServerUtilityBase server);
        TrackViewModel GetTrackViewModel();
    }
}
