using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Models;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminSingerPresentationService : GetArrayImage, IAdminSingerPresentationService
    {
        private readonly ISingerDomainService singerDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly ITrackDomainService trackDomainService;

        public AdminSingerPresentationService(
            ISingerDomainService singerDomainService,
            IAlbumDomainService albumDomainService,
            ITrackDomainService trackDomainService)
        {
            this.singerDomainService = singerDomainService;
            this.albumDomainService = albumDomainService;
            this.trackDomainService = trackDomainService;
        }

        public EditSingerViewModel GetEditSingerViewModel(int id)
        {
            return Mapper.Map<Singer, EditSingerViewModel>(singerDomainService.GetSingerById(id));
        }

        public void EditSinger(EditSingerViewModel singerView)
        {
            Singer singer = singerDomainService.GetSingerWithImage(singerView.Id);
            Mapper.Map(singerView, singer);

            if (singerView.SingerImage != null)
            {
                singer.SingerImage.ImageData = GetArray(singerView.SingerImage);
            }

            singerDomainService.Entry(singer).State = EntityState.Modified;
            singerDomainService.SaveChanges();
        }

        public List<AdminSingerViewModel> GetAdminSingersViewModel()
        {
            List<AdminSingerViewModel> singers = new List<AdminSingerViewModel>();

            singerDomainService.GetSingersWithAlbums()
                .ForEach(x => singers.Add(Mapper.Map<AdminSingerViewModel>(x)));

            foreach (var singer in singers)
            {
                List<Album> albumsWithTracks = albumDomainService
                    .GetAlbumsWithTracksBySingerId(singer.Id);
                List<AdminAlbumViewModel> albums = new List<AdminAlbumViewModel>();

                foreach (var albumWithTracks in albumsWithTracks)
                {
                    albumWithTracks.Tracks = trackDomainService
                        .GetTracksWithTrackFileByAlbumId(albumWithTracks.Id);
                    AdminAlbumViewModel album = Mapper.Map<AdminAlbumViewModel>(albumWithTracks);

                    albums.Add(album);
                }

                singer.Albums = albums;
            }

            return singers;
        }

        public void AddSinger(CreateSingerViewModel singerView)
        {
            Singer singer = Mapper.Map<CreateSingerViewModel, Singer>(singerView);

            singer.SingerImage.ImageData = GetArray(singerView.SingerImage);

            singerDomainService.Entry(singer).State = EntityState.Added;
            singerDomainService.SaveChanges();
        }

        public AlbumNames GetAlbumNamesBySingerId(int id)
        {
            return singerDomainService.GetAlbumNamesBySingerId(id);
        }

        public DeleteSingerViewModel GetDeleteSingerViewModel(int id)
        {
            Singer singer = singerDomainService.GetSingerById(id);
            return Mapper.Map<Singer, DeleteSingerViewModel>(singer);
        }

        public SingerImage RedirectSingerImage(int id)
        {
            return singerDomainService.RedirectSingerImage(id);
        }

        public void DeleteSinger(int id)
        {
            singerDomainService.GetAlbumsIdBySingerId(id)
                .ForEach(x => albumDomainService.DeleteAlbum(x));

            singerDomainService.DeleteSinger(id);
        }

        public bool IsExistSinger(int id)
        {
            return singerDomainService.IsExistSinger(id);
        }
    }
}