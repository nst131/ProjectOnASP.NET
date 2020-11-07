using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using Microsoft.Ajax.Utilities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;
using System.Data.Entity;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminAlbumPresentationService : GetArrayImage, IAdminAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly ISingerDomainService singerDomainService;
        private readonly ITrackDomainService trackDomainService;

        public AdminAlbumPresentationService(IAlbumDomainService albumDomain,
            ISingerDomainService singerDomain,
            ITrackDomainService trackDomainService)
        {
            this.albumDomainService = albumDomain;
            this.singerDomainService = singerDomain;
            this.trackDomainService = trackDomainService;
        }

        public CreateAlbumViewModel GetCreateAlbumViewModel()
        {
            return new CreateAlbumViewModel()
            {
                SingerId = singerDomainService.GetFirstSingerId(),
                SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name")
            };
        }

        public CreateAlbumViewModel GetCreateAlbumViewModel(CreateAlbumViewModel albumView)
        {
            albumView.SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name");

            return albumView;
        }

        public EditAlbumViewModel GetEditAlbumViewModel(int id)
        {
            EditAlbumViewModel editAlbum = Mapper.Map<Album, EditAlbumViewModel>(albumDomainService.GetAlbumById(id));
            editAlbum.SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name");

            return editAlbum;
        }

        public EditAlbumViewModel GetEditAlbumViewModel(EditAlbumViewModel editAlbum)
        {
            editAlbum.SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name");

            return editAlbum;
        }

        public void EditAlbum(EditAlbumViewModel albumView)
        {
            Album album = albumDomainService.GetAlbumWithImage(albumView.Id);
            Mapper.Map<EditAlbumViewModel, Album>(albumView, album);

            if (albumView.AlbumImage != null)
            {
                album.AlbumImage.ImageData = GetArray(albumView.AlbumImage);
            }

            album.Singer = singerDomainService.GetSingerById(albumView.SingerId);

            albumDomainService.Entry(album).State = EntityState.Modified;
            albumDomainService.SaveChanges();
        }

        public void AddAlbum(CreateAlbumViewModel albumView)
        {
            Album album = Mapper.Map<CreateAlbumViewModel, Album>(albumView);

            album.AlbumImage.ImageData = GetArray(albumView.AlbumImage);
            album.Singer = singerDomainService.GetSingerById(albumView.SingerId);

            albumDomainService.Entry(album).State = EntityState.Added;
            albumDomainService.SaveChanges();

        }

        public bool IsExistAlbum(int id)
        {
            return albumDomainService.IsExistAlbum(id);
        }

        public DeleteAlbumViewModel GetDeleteAlbumViewModel(int id)
        {
            Album album = albumDomainService.GetAlbumById(id);
            return Mapper.Map<Album, DeleteAlbumViewModel>(album);
        }

        public AlbumImage RedirectAlbumImage(int id)
        {
            return albumDomainService.RedirectAlbumImage(id);
        }

        public void DeleteAlbum(int id)
        {
            albumDomainService.DeleteAlbum(id);
        }

        public void DeleteTrackFileByAlbumId(int id)
        {
            albumDomainService.GetAlbumWithTracks(id).Tracks
                .ForEach(x => trackDomainService.DeleteTrackFileByName(x.Name));
        }
    }
}