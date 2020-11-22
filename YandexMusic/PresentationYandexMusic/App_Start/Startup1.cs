using InfastructureYandexMusic.ApplicationManagers;
using InfastructureYandexMusic.Context;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(PresentationYandexMusic.App_Start.Startup1))]

namespace PresentationYandexMusic.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CoreDbContext.Create);

            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
                ExpireTimeSpan = new System.TimeSpan(0, 30, 0),
                CookieName = "YandexMusicCookie",
            });
        }
    }
}
