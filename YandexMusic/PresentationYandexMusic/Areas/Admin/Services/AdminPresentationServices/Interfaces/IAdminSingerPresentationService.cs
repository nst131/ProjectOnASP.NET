using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
using PresentationYandexMusic.Areas.Admin.ViewModel;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces
{
    public interface IAdminSingerPresentationService : IAdminBasePresentationService
    {
        void AddSinger(SingerViewModel singerView);
        AlbumNames GetAlbumNamesBySingerId(int id);
    }
}