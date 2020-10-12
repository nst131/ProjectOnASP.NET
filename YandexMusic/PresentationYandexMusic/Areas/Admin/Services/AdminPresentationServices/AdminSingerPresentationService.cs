using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Data.Entity;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminSingerPresentationService : GetArrayImage, IAdminSingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;

        public AdminSingerPresentationService(ISingerDomainService singerDomainService)
        {
            this.singerDomainService = singerDomainService;
        }

        public void AddSinger(SingerViewModel singerView)
        {
            Singer singer = Mapper.Map<SingerViewModel, Singer>(singerView);

            singer.SingerImage.ImageData = GetArray(singerView.SingerImage);

            singerDomainService.Entry(singer).State = EntityState.Added;
            singerDomainService.SaveChanges();
        }
    }
}