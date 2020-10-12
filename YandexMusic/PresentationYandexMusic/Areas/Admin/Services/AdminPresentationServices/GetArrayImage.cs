using System.Web;

namespace PresentationYandexMusic.Areas.Admin.Services.AdminPresentationServices
{
    public class GetArrayImage
    {
        public byte[] GetArray(HttpPostedFileBase image)
        {
            byte[] vs = new byte[image.ContentLength];

            image.InputStream
                .Read(vs, 0, image.ContentLength);

            return vs;
        }
    }
}