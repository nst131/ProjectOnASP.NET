using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel
{
    public class PlaylistViewModel
    {
        public string PlaylistName { get; set; }
        public HttpPostedFileBase PlaylistImage { get; set; }
    }
}