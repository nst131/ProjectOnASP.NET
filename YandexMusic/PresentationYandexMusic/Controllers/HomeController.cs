using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;
using System.Web.Mvc;

namespace PresentationYandexMusic.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IHomePresentationService homePresentation;

        public HomeController(IHomePresentationService homePresentation)
        {
            this.homePresentation = homePresentation;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ViewResult StartPage()
        {
            return View();
        }

        public virtual ViewResult MainPage()
        {
            return View(homePresentation.GetMainViewModel());
        }

        public virtual FileResult GetImageByName(string name)
        {
            string pathFile = Server.MapPath("~/images/" + name);
            string typeFile = "image/jpeg";

            return File(pathFile, typeFile);
        }
    }
}