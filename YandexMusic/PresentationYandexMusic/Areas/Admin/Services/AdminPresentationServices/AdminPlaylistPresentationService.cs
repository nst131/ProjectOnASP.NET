using System.Data.Entity;
using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Playlist;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminPlaylistPresentationService : GetArrayImage, IAdminPlaylistPresentationService
    {
        private readonly IPlaylistDomainService playlistDomainService;

        public AdminPlaylistPresentationService(IPlaylistDomainService playlistDomain)
        {
            playlistDomainService = playlistDomain;
        }

        public void AddPlaylist(CreatePlaylistViewModel playlistModel)
        {
            Playlist playlist = Mapper.Map<CreatePlaylistViewModel, Playlist>(playlistModel);

            playlist.PlaylistImage.ImageData = GetArray(playlistModel.PlaylistImage);

            playlistDomainService.Entry(playlist).State = EntityState.Added;
            playlistDomainService.SaveChanges();
        }

        public bool IsExistPlaylist(int id)
        {
            return playlistDomainService.IsExistPlaylist(id);
        }

        public DeletePlaylistViewModel GetDeletePlaylistViewModel(int id)
        {
            return Mapper.Map<Playlist, DeletePlaylistViewModel>(playlistDomainService.GetPlaylistById(id));
        }

        public void DeletePlaylist(int id)
        {
            playlistDomainService.DeletePlaylist(id);
        }

        public PlaylistImage RedirectPlaylistImage(int id)
        {
            return playlistDomainService.RedirectPlaylistImage(id);
        }
    }
}