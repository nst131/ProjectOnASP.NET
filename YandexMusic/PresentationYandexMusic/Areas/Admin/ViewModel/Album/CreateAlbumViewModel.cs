using System.Web;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Album
{
    public class CreateAlbumViewModel
    {
        public string AlbumName { get; set; }
        public HttpPostedFileBase AlbumImage { get; set; }

        public int SingerId { get; set; }
        public SelectList SelectListSingers { get; set; }
    }
}