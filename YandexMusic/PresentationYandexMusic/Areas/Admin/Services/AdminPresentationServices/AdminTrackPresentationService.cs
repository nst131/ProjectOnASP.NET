using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminTrackPresentationService : GetArrayImage, IAdminTrackPresentationService
    {
        private readonly ITrackDomainService trackDomainService;
        private readonly ISingerDomainService singerDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IPlaylistDomainService playlistDomainService;
        private readonly INoveltyDomainService noveltyDomainService;
        private readonly IPopularDomainService popularDomainService;

        private const string pathServerBefore = "~/ServerFiles/";
        private const string pathServerAfter = "../../../ServerFiles/";

        public AdminTrackPresentationService(ITrackDomainService trackDomainService,
            ISingerDomainService singerDomainService,
            IAlbumDomainService albumDomainService,
            IGenreDomainService genreDomainService,
            IPlaylistDomainService playlistDomainService,
            INoveltyDomainService noveltyDomainService,
            IPopularDomainService popularDomainService)
        {
            this.trackDomainService = trackDomainService;
            this.singerDomainService = singerDomainService;
            this.albumDomainService = albumDomainService;
            this.genreDomainService = genreDomainService;
            this.playlistDomainService = playlistDomainService;
            this.noveltyDomainService = noveltyDomainService;
            this.popularDomainService = popularDomainService;
        }

        public TrackViewModel GetTrackViewModel()
        {
            return new TrackViewModel()
            {
                SingerId = 1,
                SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name"),

                PlaylistList = playlistDomainService.GetDictionaryPlaylist(),

                AlbumId = 1,
                SelectListAlbums = new SelectList(albumDomainService.GetListAlbums(), "Id", "Name"),

                GenreId = 1,
                SelectListGenre = new SelectList(genreDomainService.GetListGenre(), "Id", "Name"),

                NoveltyList = noveltyDomainService.GetDictionaryNovelty(),

                PopularList = popularDomainService.GetDictionaryPopular()
            };
        }

        public void AddTrack(TrackViewModel trackModel, HttpServerUtilityBase server)
        {
            Track track = Mapper.Map<TrackViewModel, Track>(trackModel);

            track.TrackImage.ImageData = GetArray(trackModel.TrackImage);

            string name = trackModel.TrackFile.FileName;
            trackModel.TrackFile.SaveAs(server.MapPath(pathServerBefore + name));
            track.TrackFile.FileLocation = pathServerAfter + name;

            trackDomainService.Entry(track).State = EntityState.Added;
            trackDomainService.SaveChanges();
        }
    }
}