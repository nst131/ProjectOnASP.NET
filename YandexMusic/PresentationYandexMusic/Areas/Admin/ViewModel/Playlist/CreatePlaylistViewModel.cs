using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Playlist
{
    public class CreatePlaylistViewModel
    {
        public string PlaylistName { get; set; }
        public HttpPostedFileBase PlaylistImage { get; set; }
    }
}