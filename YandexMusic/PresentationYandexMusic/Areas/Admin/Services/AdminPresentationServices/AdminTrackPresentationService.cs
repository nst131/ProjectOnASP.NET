using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DomainYandexMusic.Entities;
using DomainYandexMusic.Services.Interfaces.EntitiesInterfaces;
using Microsoft.Ajax.Utilities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Track;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class AdminTrackPresentationService : GetArrayImage, IAdminTrackPresentationService
    {
        private const string PathServerBefore = "~/ServerFiles/";
        private const string PathServerAfter = "../../../ServerFiles/";

        private readonly ITrackDomainService trackDomainService;
        private readonly ISingerDomainService singerDomainService;
        private readonly IAlbumDomainService albumDomainService;
        private readonly IGenreDomainService genreDomainService;
        private readonly IPlaylistDomainService playlistDomainService;
        private readonly INoveltyDomainService noveltyDomainService;
        private readonly IPopularDomainService popularDomainService;

        public AdminTrackPresentationService(
            ITrackDomainService trackDomainService,
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

        public EditTrackViewModel GetEditTrackViewModel(int id)
        {
            EditTrackViewModel track = Mapper.Map<Track, EditTrackViewModel>(trackDomainService.GetTrackById(id));

            return GetEditTrackViewModel(track);
        }

        public EditTrackViewModel GetEditTrackViewModel(EditTrackViewModel track)
        {
            track.SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name");
            track.SelectListAlbums = new SelectList(singerDomainService.GetAlbumsBySingerId(track.SingerId), "Id", "Name");
            track.SelectListGenre = new SelectList(genreDomainService.GetListGenre(), "Id", "Name");
            track.NoveltyList = noveltyDomainService.GetDictionaryNovelty();
            track.PopularList = popularDomainService.GetDictionaryPopular();
            track.PlaylistList = playlistDomainService.GetDictionaryPlaylist();

            return track;
        }

        public void EditTrack(EditTrackViewModel trackView, HttpServerUtilityBase server)
        {
            Track track = trackDomainService.GetTrackWithImageAndFileTrack(trackView.Id);
            Mapper.Map(trackView, track);

            if (trackView.TrackImage != null)
            {
                track.TrackImage.ImageData = GetArray(trackView.TrackImage);
            }

            if (trackView.TrackFile != null)
            {
                string name = trackView.TrackFile.FileName;
                trackView.TrackFile.SaveAs(server.MapPath(PathServerBefore + name));
                track.TrackFile.FileLocation = PathServerAfter + name;
            }

            trackDomainService.Entry(track).State = EntityState.Modified;
            trackDomainService.SaveChanges();
        }

        public CreateTrackViewModel GetTrackViewModel()
        {
            return new CreateTrackViewModel()
            {
                SingerId = singerDomainService.GetFirstSingerId(),
                AlbumId = singerDomainService.GetFirstAlbumIdBySingerId(singerDomainService.GetFirstSingerId()),
                GenreId = genreDomainService.GetFirstGenreId(),
                SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name"),
                SelectListGenre = new SelectList(genreDomainService.GetListGenre(), "Id", "Name"),
                SelectListAlbums = new SelectList(singerDomainService.GetAlbumsBySingerId(singerDomainService.GetFirstSingerId()), "Id", "Name"),
                PlaylistList = playlistDomainService.GetDictionaryPlaylist(),

                NoveltyList = noveltyDomainService.GetDictionaryNovelty(),
                PopularList = popularDomainService.GetDictionaryPopular()
            };
        }

        public CreateTrackViewModel GetTrackViewModel(CreateTrackViewModel trackView)
        {
            trackView.SelectListSingers = new SelectList(singerDomainService.GetListSingers(), "Id", "Name");
            trackView.SelectListGenre = new SelectList(genreDomainService.GetListGenre(), "Id", "Name");
            trackView.SelectListAlbums = new SelectList(singerDomainService.GetAlbumsBySingerId(trackView.SingerId), "Id", "Name");
            trackView.PlaylistList = playlistDomainService.GetDictionaryPlaylist();
            trackView.NoveltyList = noveltyDomainService.GetDictionaryNovelty();
            trackView.PopularList = popularDomainService.GetDictionaryPopular();

            return trackView;
        }

        public void AddTrack(CreateTrackViewModel trackModel, HttpServerUtilityBase server)
        {
            Track track = Mapper.Map<CreateTrackViewModel, Track>(trackModel);

            track.Singer = singerDomainService.GetSingerById(trackModel.SingerId);
            track.Album = albumDomainService.GetAlbumById(trackModel.AlbumId);
            track.Genre = genreDomainService.GetGenreById(trackModel.GenreId);
            track.Popular = popularDomainService.GetPopularById(trackModel.PopularId);
            track.Novelty = noveltyDomainService.GetNoveltyById(trackModel.NoveltyId);

            track.TrackImage.ImageData = GetArray(trackModel.TrackImage);

            trackModel.PlaylistArrayId
                .ForEach(x => track.Playlists.Add(playlistDomainService.GetPlaylistById(x)));

            string name = trackModel.TrackFile.FileName;
            trackModel.TrackFile.SaveAs(server.MapPath(PathServerBefore + name));
            track.TrackFile.FileLocation = PathServerAfter + name;

            trackDomainService.Entry(track).State = EntityState.Added;
            trackDomainService.SaveChanges();
        }

        public TrackImage RedirectTrackImage(int id)
        {
            return trackDomainService.RedirectTrackImage(id);
        }

        public bool IsExistTrack(int id)
        {
            return trackDomainService.IsExistTrack(id);
        }

        public DeleteTrackViewModel GetDeleteTrackViewModel(int id)
        {
            return Mapper.Map<Track, DeleteTrackViewModel>(trackDomainService.GetTrackById(id));
        }

        public void DeleteTrack(int id)
        {
            trackDomainService.DeleteTrack(id);
        }
    }
}