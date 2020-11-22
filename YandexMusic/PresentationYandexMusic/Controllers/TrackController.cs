using System.Web.Mvc;
using DomainYandexMusic.Entities;
using Microsoft.AspNet.Identity;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    public partial class TrackController : Controller
    {
        private readonly ITrackPresentationService trackPresentation;

        public TrackController(ITrackPresentationService trackPresentation)
        {
            this.trackPresentation = trackPresentation;
        }

        public virtual FileResult GetTrackImage(int id)
        {
            TrackImage image = trackPresentation.RedirecttrackImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }

        public virtual ViewResult GetTracksByGenre(int id)
        {
            return View(trackPresentation.GetTrackGenreViewModel(id, User.Identity.GetUserId()));
        }

        public virtual ViewResult LikedTrackView()
        {
            return View(trackPresentation.GetLikedTrackView(User.Identity.GetUserId()));
        }
    }
}