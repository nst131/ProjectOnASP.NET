using DomainYandexMusic.Entities;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel.Playlist;
using System.Net;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminPlaylistController : Controller
    {
        private readonly IAdminPlaylistPresentationService adminPlaylist;

        public AdminPlaylistController(IAdminPlaylistPresentationService adminPlaylist)
        {
            this.adminPlaylist = adminPlaylist;
        }

        [HttpGet]
        public virtual ViewResult CreatePlaylist()
        {
            return View(new CreatePlaylistViewModel());
        }
        [HttpPost]
        public virtual ActionResult CreatePlaylist(CreatePlaylistViewModel playlistView)
        {
            if (ModelState.IsValid)
            {
                adminPlaylist.AddPlaylist(playlistView);

                return Redirect("/Admin/Admin/Success");
            }

            return PartialView("FormCreatePlaylist", playlistView);
        }


        [HttpGet]
        public virtual ActionResult DeletePlaylist(int? id)
        {
            if (id == null || !adminPlaylist.IsExistPlaylist((int)id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(adminPlaylist.GetDeletePlaylistViewModel((int)id));
        }
        [HttpPost]
        public virtual ActionResult DeletePlaylist(int id)
        {
            adminPlaylist.DeletePlaylist(id);

            return Redirect("/Admin/Admin/AdminLayout");
        }

        public virtual FileResult GetPlaylistImage(int id)
        {
            PlaylistImage image = adminPlaylist.RedirectPlaylistImage(id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }
    }
}