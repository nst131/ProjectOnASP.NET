using System.Web.Mvc;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminController : Controller
    {
        private readonly IAdminSingerPresentationService adminSinger;

        public AdminController(IAdminSingerPresentationService adminSinger)
        {
            this.adminSinger = adminSinger;
        }

        [Authorize(Roles = "admin")]
        public virtual ViewResult AdminLayout()
        {
            return View();
        }

        public virtual PartialViewResult FormSuccess()
        {
            return PartialView("FormSuccess");
        }

        public virtual PartialViewResult GetAllSingersWithData()
        {
            return PartialView("AdminSingerData", adminSinger.GetAdminSingersViewModel());
        }
    }
}