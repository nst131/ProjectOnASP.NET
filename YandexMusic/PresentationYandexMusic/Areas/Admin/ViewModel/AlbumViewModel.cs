using System.Web;
using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin.ViewModel
{
    public class AlbumViewModel
    {
        public string AlbumName { get; set; }
        public HttpPostedFileBase AlbumImage { get; set; }

        public int SingerId { get; set; }
        public SelectList SelectListSingers { get; set; }
    }
}