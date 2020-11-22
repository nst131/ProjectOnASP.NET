using System.Web.Mvc;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Genre;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminGenreController : Controller
    {
        private readonly IAdminGenrePresentationService adminGenre;

        public AdminGenreController(IAdminGenrePresentationService adminGenre)
        {
            this.adminGenre = adminGenre;
        }

        [HttpGet]
        public virtual ViewResult CreateGenre()
        {
            return View(new CreateGenreViewModel());
        }

        [HttpPost]
        public virtual ActionResult CreateGenre(CreateGenreViewModel genreModel)
        {
            if (ModelState.IsValid)
            {
                adminGenre.AddGenre(genreModel);

                return Redirect(Url.Action(MVC.Admin.AdminGenre.FormGenreSuccess()));
            }

            return PartialView("FormCreateGenre", genreModel);
        }

        public virtual PartialViewResult FormGenreSuccess()
        {
            return PartialView("FormGenreSuccess", new CreateGenreViewModel());
        }
    }
}