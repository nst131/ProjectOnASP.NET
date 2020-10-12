using System.Web.Mvc;

namespace PresentationYandexMusic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}