using DomainYandexMusic.Services.Interfaces;
using System.Web;

namespace DomainYandexMusic.Services
{
    public class CheckFile : ICheckFile
    {
        public bool CheckJpg(HttpPostedFileBase file)
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

        public bool CheckMP3(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return false;
            }

            if (file.ContentType == "audio/mpeg")
            {
                return true;
            }

            return false;
        }
    }
}
