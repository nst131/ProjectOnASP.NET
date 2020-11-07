using DomainYandexMusic.Entities;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Web.Mvc;

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
            return View(singerPresentation.GetSingersViewModel());
        }

        [Route("Singer/{id:int}")]
        public virtual ViewResult SingerDetail(int id)
        {
            return View(singerPresentation.GetSingerDetailViewModel(id));
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