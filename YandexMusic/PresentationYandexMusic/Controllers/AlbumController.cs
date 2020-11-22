using System.Web.Mvc;
using DomainYandexMusic.Entities;
using Microsoft.AspNet.Identity;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    public partial class AlbumController : Controller
    {
        private readonly IAlbumPresentationService albumPresentation;

        public AlbumController(IAlbumPresentationService albumPresentation)
        {
            this.albumPresentation = albumPresentation;
        }

        public virtual FileResult GetAlbumImage(int id)
        {
            AlbumImage image = albumPresentation.RedirectAlbumImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }

        [Route("AlbumDetail/{id:int}")]
        public virtual ViewResult AlbumDetail(int id)
        {
            return View(albumPresentation.GetAlbumDetailViewModel(id, User.Identity.GetUserId()));
        }
    }
}