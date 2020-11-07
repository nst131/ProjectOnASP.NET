using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Genre
{
    public class CreateGenreViewModel
    {
        public string GenreName { get; set; }
        public HttpPostedFileBase GenreImage { get; set; }
    }
}