using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Data.Entity;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminPlaylistPresentationService : GetArrayImage, IAdminPlaylistPresentationService
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public AdminPlaylistPresentationService(IPlaylistDomainService playlistDomain)
        {
            this.playlistDomainService = playlistDomain;
        }

        public void AddPlaylist(PlaylistViewModel playlistModel)
        {
            Playlist playlist = Mapper.Map<PlaylistViewModel, Playlist>(playlistModel);

            playlist.PlaylistImage.ImageData = GetArray(playlistModel.PlaylistImage);

            playlistDomainService.Entry(playlist).State = EntityState.Added;
            playlistDomainService.SaveChanges();
        }
    }
}