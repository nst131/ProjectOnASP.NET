using DomainYandexMusic.Entities;
using DomainYandexMusic.UnitOfWork;
using PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices.Interfaces;
using PresentationYandexMusic.Areas.Admin.ViewModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAdminGenrePresentationService adminGenre;
        private readonly IAdminSingerPresentationService adminSinger;
        private readonly IAdminAlbumPresentationService adminAlbum;
        private readonly IAdminPlaylistPresentationService adminPlaylist;
        private readonly IAdminTrackPresentationService adminTrack;

        public AdminController(IUnitOfWork unitOfWork,
            IAdminGenrePresentationService adminGenre,
            IAdminSingerPresentationService adminSinger,
            IAdminAlbumPresentationService adminAlbum,
            IAdminPlaylistPresentationService adminPlaylist,
            IAdminTrackPresentationService adminTrack)
        {
            this.unitOfWork = unitOfWork;
            this.adminGenre = adminGenre;
            this.adminSinger = adminSinger;
            this.adminAlbum = adminAlbum;
            this.adminPlaylist = adminPlaylist;
            this.adminTrack = adminTrack;
        }
        //----------------------------------- Start -----------------------------
        public ViewResult AdminLayout()
        {
            return View();
        }

        //----------------------------------- Track ------------------------------
        [HttpGet]
        public ViewResult CreateTrack()
        {
            return View(adminTrack.GetTrackViewModel());
        }
        [HttpPost]
        public ActionResult CreateTrack(TrackViewModel trackModel)
        {
            if (ModelState.IsValid)
            {
                adminTrack.AddTrack(trackModel,Server);

                return Redirect("AdminLayout");
            }

            return PartialView("FormTrack", trackModel);
        }

        //----------------------------------- Genre --------------------------------
        [HttpGet]
        public ViewResult CreateGenre()
        {
            return View(new GenreViewModel());
        }
        [HttpPost]
        public ActionResult CreateGenre(GenreViewModel genreModel)
        {
            if (ModelState.IsValid)
            {
                adminGenre.AddGenre(genreModel);

                return Redirect("AdminLayout");
            }

            return PartialView("FormGenre", genreModel);
        }

        //----------------------------------- Singer ----------------------------------
        [HttpGet]
        public ViewResult CreateSinger()
        {
            return View(new SingerViewModel());
        }
        [HttpPost]
        public ActionResult CreateSinger(SingerViewModel singerModel)
        {
            if (ModelState.IsValid)
            {
                adminSinger.AddSinger(singerModel);

                return Redirect("AdminLayout");
            }

            return PartialView("FormGenre", singerModel);
        }

        //---------------------------------- Album --------------------------------
        [HttpGet]
        public ViewResult CreateAlbum()
        {
            return View(adminAlbum.GetAlbumViewModel());
        }
        [HttpPost]
        public ActionResult CreateAlbum(AlbumViewModel albumView)
        {
            if (ModelState.IsValid)
            {
                adminAlbum.AddAlbum(albumView);

                return Redirect("AdminLayout");
            }

            return PartialView("FormAlbum", albumView);
        }

        //----------------------------------- Playlist --------------------------------
        [HttpGet]
        public ViewResult CreatePlaylist()
        {
            return View(new PlaylistViewModel());
        }
        [HttpPost]
        public ActionResult CreatePlaylist(PlaylistViewModel playlistView)
        {
            if (ModelState.IsValid)
            {
                adminPlaylist.AddPlaylist(playlistView);

                return Redirect("AdminLayout");
            }

            return PartialView("FormPlaylist", playlistView);
        }

        //---------------------------------- Other -----------------------------------
        public ActionResult GetTrack(int id)
        {
            TrackFile trackFile = unitOfWork.Set<TrackFile>().FirstOrDefault(x => x.Id == id);
            return View(trackFile);
        }

        public FileResult GetImage(int Id)
        {
            GenreImage image = unitOfWork.Set<GenreImage>().FirstOrDefault(x => x.Id == Id);

            if (image != null)
            {
                return File(image.ImageData, image.ImageMimeType);
            }

            return null;
        }
    }
}