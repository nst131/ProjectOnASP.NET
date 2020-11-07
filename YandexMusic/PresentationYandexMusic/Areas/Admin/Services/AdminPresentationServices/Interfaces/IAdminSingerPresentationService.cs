using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;
using System.Collections.Generic;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminSingerPresentationService : IAdminBasePresentationService
    {
        void AddSinger(CreateSingerViewModel singerView);
        void DeleteSinger(int id);
        void EditSinger(EditSingerViewModel singerView);
        List<AdminSingerViewModel> GetAdminSingersViewModel();
        AlbumNames GetAlbumNamesBySingerId(int id);
        DeleteSingerViewModel GetDeleteSingerViewModel(int id);
        EditSingerViewModel GetEditSingerViewModel(int id);
        bool IsExistSinger(int id);
        SingerImage RedirectSingerImage(int id);
    }
}