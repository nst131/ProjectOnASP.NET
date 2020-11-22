using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    [RoutePrefix("Playlist")]
    public partial class PlaylistController : Controller
    {
        private readonly IPlaylistPresentationService playlistPresentation;

        public PlaylistController(IPlaylistPresentationService playlistPresentation)
        {
            this.playlistPresentation = playlistPresentation;
        }

        [Route("AddTrackInPlaylistBeloved/{id:int}")]
        public void AddTrackInPlaylistBelovedByTrackId(int id)
        {
            playlistPresentation.AddTrackInPlaylistBeloved(User.Identity.GetUserId(), id);
        }

        [Route("DeleteTrackInPlaylistBeloved/{id:int}")]
        public void DeleteTrackInPlaylistBelovedByTrackId(int id)
        {
            playlistPresentation.DeleteTrackInPlaylistBeloved(User.Identity.GetUserId(), id);
        }

        [Route("GetLikedTracksView")]
        public virtual PartialViewResult GetLikedTracksView()
        {
            return PartialView(MVC.Track.Views.LikedTrack, playlistPresentation.GetTracksInPlaylistBeloved(User.Identity.GetUserId()));
        }
    }
}