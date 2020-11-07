using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Track;
using System.Net;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminTrackController : Controller
    {
        private readonly IAdminTrackPresentationService adminTrack;
        private readonly IAdminSingerPresentationService adminSinger;

        public AdminTrackController(IAdminTrackPresentationService adminTrack,
            IAdminSingerPresentationService adminSinger)
        {
            this.adminTrack = adminTrack;
            this.adminSinger = adminSinger;
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ViewResult CreateTrack()
        {
            return View(adminTrack.GetTrackViewModel());
        }
        [HttpPost]
        public virtual ActionResult CreateTrack(CreateTrackViewModel trackModel)
        {
            if (ModelState.IsValid)
            {
                adminTrack.AddTrack(trackModel, Server);

                return Redirect("/Admin/Admin/AdminLayout");
            }

            return View("CreateTrack", adminTrack.GetTrackViewModel(trackModel));
        }

        [HttpGet]
        public virtual ViewResult EditTrack(int id)
        {
            return View(adminTrack.GetEditTrackViewModel(id));
        }
        [HttpPost]
        public virtual ActionResult EditTrack(EditTrackViewModel trackView)
        {
            if (ModelState.IsValid)
            {
                adminTrack.EditTrack(trackView, Server);

                return Redirect("/Admin/Admin/AdminLayout");
            }

            return View("EditTrack", adminTrack.GetEditTrackViewModel(trackView));
        }

        [HttpGet]
        public virtual ActionResult DeleteTrack(int? id)
        {
            if (id == null || !adminTrack.IsExistTrack((int)id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(adminTrack.GetDeleteTrackViewModel((int)id));
        }
        [HttpPost]
        public virtual ActionResult DeleteTrack(int id)
        {
            adminTrack.DeleteTrack(id);

            return Redirect("/Admin/Admin/AdminLayout");
        }

        public virtual FileResult GetTrackImage(int id)
        {
            TrackImage image = adminTrack.RedirectTrackImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }

        public virtual JsonResult ReplaceItem(int id)
        {
            return Json(adminSinger.GetAlbumNamesBySingerId(id), JsonRequestBehavior.AllowGet);
        }
    }
}