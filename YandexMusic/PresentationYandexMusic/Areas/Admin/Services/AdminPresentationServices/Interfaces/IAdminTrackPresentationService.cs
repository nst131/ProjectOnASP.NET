using System.Web;
using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.ViewModel.Track;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminTrackPresentationService : IAdminBasePresentationService
    {
        void AddTrack(CreateTrackViewModel trackModel, HttpServerUtilityBase server);

        void DeleteTrack(int id);

        void EditTrack(EditTrackViewModel trackView, HttpServerUtilityBase server);

        DeleteTrackViewModel GetDeleteTrackViewModel(int id);

        EditTrackViewModel GetEditTrackViewModel(int id);

        EditTrackViewModel GetEditTrackViewModel(EditTrackViewModel track);

        CreateTrackViewModel GetTrackViewModel();

        CreateTrackViewModel GetTrackViewModel(CreateTrackViewModel trackView);

        bool IsExistTrack(int id);

        TrackImage RedirectTrackImage(int id);
    }
}
