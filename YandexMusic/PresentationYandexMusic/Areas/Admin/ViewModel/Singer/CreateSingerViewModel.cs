using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Singer
{
    public class CreateSingerViewModel
    {
        public string SingerName { get; set; }
        public HttpPostedFileBase SingerImage { get; set; }
    }
}