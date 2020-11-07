using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Models.AlbumModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Services.EntitiesPresentationService
{
    public class AlbumPresentationService : IAlbumPresentationService
    {
        private readonly IAlbumDomainService albumDomainService;
        private readonly ITrackDomainService trackDomainService;

        public AlbumPresentationService(IAlbumDomainService albumDomainService, ITrackDomainService trackDomainService)
        {
            this.albumDomainService = albumDomainService;
            this.trackDomainService = trackDomainService;
        }

        public AlbumImage RedirectAlbumImage(int id)
        {
            return albumDomainService.RedirectAlbumImage(id);
        }

        public AlbumDetailViewModel GetAlbumDetailViewModel(int id)
        {
            AlbumDetailViewModel album = Mapper.Map<AlbumDetailViewModel>(albumDomainService.GetAlbumWithTracksAndSinger(id));

            album.LikedTrack = trackDomainService.GetLikedTracksWithSinger();
            album.AmountTracks = albumDomainService.AmountTrackInAlbumByAlbumId(id);

            return album;
        }
    }
}