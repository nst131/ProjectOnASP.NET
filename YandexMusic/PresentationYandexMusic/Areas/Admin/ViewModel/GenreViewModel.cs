using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel
{
    public class GenreViewModel
    {
        public string GenreName { get; set; }
        public HttpPostedFileBase GenreImage { get; set; }
    }
}