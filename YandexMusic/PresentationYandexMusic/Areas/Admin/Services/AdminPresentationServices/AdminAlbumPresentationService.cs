using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Data.Entity;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminAlbumPresentationService: GetArrayImage, IAdminAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly ISingerDomainService singerDomainService;

        public AdminAlbumPresentationService(
            IAlbumDomainService albumDomain,ISingerDomainService singerDomain)
        {
            this.albumDomainService = albumDomain;
            this.singerDomainService = singerDomain;
        }

        public AlbumViewModel GetAlbumViewModel()
        {
            return new AlbumViewModel()
            {
                SingerId = 1,
                SelectListSingers = new SelectList(singerDomainService.GetListSingers(),"Id","Name") 
            };
        }

        public void AddAlbum(AlbumViewModel albumView)
        {
            if(singerDomainService.IsExistSinger(albumView.SingerId))
            {
                Album album = Mapper.Map<AlbumViewModel, Album>(albumView);

                album.AlbumImage.ImageData = GetArray(albumView.AlbumImage);
                album.Singer = singerDomainService.GetSingerById(albumView.SingerId);

                albumDomainService.Entry(album).State = EntityState.Added;
                albumDomainService.SaveChanges();
            }
        }
    }
}