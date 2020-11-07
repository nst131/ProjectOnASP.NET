using System.Web;

namespace PresentationYandexMusic.Areas.Admin.ViewModel.Singer
{
    public class EditSingerViewModel
    {
        public int Id { get; set; }
        public string SingerName { get; set; }
        public HttpPostedFileBase SingerImage { get; set; }
    }
}