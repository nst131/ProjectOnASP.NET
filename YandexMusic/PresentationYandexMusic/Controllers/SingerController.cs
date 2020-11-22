using System.Web.Mvc;
using DomainYandexMusic.Entities;
using Microsoft.AspNet.Identity;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    [RoutePrefix("Singer")]
    public partial class SingerController : Controller
    {
        private readonly ISingerPresentationService singerPresentation;

        public SingerController(ISingerPresentationService singerPresentation)
        {
            this.singerPresentation = singerPresentation;
        }

        [Route("ShowAllSingers")]
        public virtual ViewResult ShowAllSingers()
        {
            return View(singerPresentation.GetSingersViewModel(User.Identity.GetUserId()));
        }

        [Route("Singer/{id:int}")]
        public virtual ViewResult SingerDetail(int id)
        {
            return View(singerPresentation.GetSingerDetailViewModel(id, User.Identity.GetUserId()));
        }

        public virtual FileResult GetSingerImage(int id)
        {
            SingerImage image = singerPresentation.RedirectSingerImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }
    }
}