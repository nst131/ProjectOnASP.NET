﻿using AutoMapper;
using PresentationYandexMusic.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PresentationYandexMusic
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacContainer.Register();

            Mapper.Initialize(cfg =>
            {
                AutoMapperConfig.Configure(cfg);
            });
        }
    }
}
