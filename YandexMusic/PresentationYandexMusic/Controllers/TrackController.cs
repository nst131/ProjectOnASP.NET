using DomainYandexMusic.Entities;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Web.Mvc;

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
            return View(trackPresentation.GetTrackGenreViewModel(id));
        }
    }
}