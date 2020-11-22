using System.Net;
using System.Web.Mvc;
using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Album;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminAlbumController : Controller
    {
        private readonly IAdminAlbumPresentationService adminAlbum;

        public AdminAlbumController(IAdminAlbumPresentationService adminAlbum)
        {
            this.adminAlbum = adminAlbum;
        }

        [HttpGet]
        public virtual ViewResult CreateAlbum()
        {
            return View(adminAlbum.GetCreateAlbumViewModel());
        }

        [HttpPost]
        public virtual ActionResult CreateAlbum(CreateAlbumViewModel albumView)
        {
            if (ModelState.IsValid)
            {
                adminAlbum.AddAlbum(albumView);

                return Redirect(Url.Action(MVC.Admin.AdminAlbum.FormAlbumSuccess()));
            }

            return PartialView("FormCreateAlbum", adminAlbum.GetCreateAlbumViewModel(albumView));
        }

        public virtual PartialViewResult FormAlbumSuccess()
        {
            return PartialView("FormAlbumSuccess", adminAlbum.GetCreateAlbumViewModel());
        }

        [HttpGet]
        public virtual ViewResult EditAlbum(int id)
        {
            return View(adminAlbum.GetEditAlbumViewModel(id));
        }

        [HttpPost]
        public virtual ActionResult EditAlbum(EditAlbumViewModel albumView)
        {
            if (ModelState.IsValid)
            {
                adminAlbum.EditAlbum(albumView);

                return Redirect(Url.Action(MVC.Admin.Admin.FormSuccess()));
            }

            return PartialView("FormEditAlbum", adminAlbum.GetEditAlbumViewModel(albumView));
        }

        [HttpGet]
        public virtual ActionResult DeleteAlbum(int? id)
        {
            if (id == null || !adminAlbum.IsExistAlbum((int)id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(adminAlbum.GetDeleteAlbumViewModel((int)id));
        }

        [HttpPost]
        public virtual ActionResult DeleteAlbum(int id)
        {
            adminAlbum.DeleteAlbum(id);

            return Redirect("/Admin/Admin/AdminLayout");
        }

        public virtual FileResult GetAlbumImage(int id)
        {
            AlbumImage image = adminAlbum.RedirectAlbumImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }
    }
}