using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using InfastructureYandexMusic.Models;
using PresentationYandexMusic.Models.AlbumModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class AlbumPresentationService : IAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly IUserDomainService userDomainService;

        public AlbumPresentationService(IAlbumDomainService albumDomainService, IUserDomainService userDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.userDomainService = userDomainService;
        }

        public AlbumImage RedirectAlbumImage(int id)
        {
            return albumDomainService.RedirectAlbumImage(id);
        }

        public AlbumDetailViewModel GetAlbumDetailViewModel(int albumId, string userId)
        {
            AlbumDetailViewModel album = Mapper.Map<AlbumDetailViewModel>(albumDomainService.GetAlbumWithTracksAndSinger(albumId));

            album.LikedTrack = userDomainService.GetTracksInPlaylistBelovedByUserIdAndPlaylistName(userId, KindPlaylist.Beloved);
            album.AmountTracks = albumDomainService.AmountTrackInAlbumByAlbumId(albumId);

            foreach (var item in album.Tracks)
            {
                if (album.LikedTrack.Contains(item))
                {
                    item.Like = true;
                }
            }

            return album;
        }
    }
}