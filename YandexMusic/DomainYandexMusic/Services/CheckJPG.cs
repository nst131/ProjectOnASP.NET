using System.Web;

namespace DomainYandexMusic.Services
{
    public class CheckJPG
    {
        public bool CheckingJpg(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return false;
            }

            if (file.ContentType == "image/jpeg")
            {
                return true;
            }

            return false;
        }
    }
}
