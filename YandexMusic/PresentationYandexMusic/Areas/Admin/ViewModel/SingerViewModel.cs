using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel
{
    public class SingerViewModel
    {
        public string SingerName { get; set; }
        public HttpPostedFileBase SingerImage { get; set; }
    }
}