using System.Web;

namespace DomainYandexMusic.Services.Interfaces
{
    public interface ICheckFile
    {
        bool CheckJpg(HttpPostedFileBase file);
        bool CheckMP3(HttpPostedFileBase file);
    }
}
