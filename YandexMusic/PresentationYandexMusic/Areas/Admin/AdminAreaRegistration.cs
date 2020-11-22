using System.Web.Mvc;

namespace PresentationYandexMusic.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "AdminLayout", id = UrlParameter.Optional });
        }
    }
}