using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Singer;
using System.Net;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminSingerController : Controller
    {
        private readonly IAdminSingerPresentationService adminSinger;


        public AdminSingerController(IAdminSingerPresentationService adminSinger)
        {
            this.adminSinger = adminSinger;
        }

        [HttpGet]
        public virtual ViewResult CreateSinger()
        {
            return View(new CreateSingerViewModel());
        }
        [HttpPost]
        public virtual ActionResult CreateSinger(CreateSingerViewModel singerModel)
        {
            if (ModelState.IsValid)
            {
                adminSinger.AddSinger(singerModel);

                return Redirect("/Admin/Admin/Success");
            }

            return PartialView("FormCreateSinger", singerModel);
        }

        [HttpGet]
        public virtual ViewResult EditSinger(int id)
        {
            return View(adminSinger.GetEditSingerViewModel(id));
        }
        [HttpPost]
        public virtual ActionResult EditSinger(EditSingerViewModel singerView)
        {
            if (ModelState.IsValid)
            {
                adminSinger.EditSinger(singerView);

                return Redirect("/Admin/Admin/FormSuccess");
            }

            return PartialView("FormEditSinger", singerView);
        }

        [HttpGet]
        public virtual ActionResult DeleteSinger(int? id)
        {
            if (id == null || !adminSinger.IsExistSinger((int)id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(adminSinger.GetDeleteSingerViewModel((int)id));
        }
        [HttpPost]
        public virtual ActionResult DeleteSinger(int id)
        {
            adminSinger.DeleteSinger(id);

            return Redirect("/Admin/Admin/AdminLayout");
        }

        public virtual FileResult GetSingerImage(int id)
        {
            SingerImage image = adminSinger.RedirectSingerImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }
    }
}