using System.Web.Optimization;

namespace PresentationYandexMusic
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Ajax").Include(
                           "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new StyleBundle("~/Content/CSSYandexMusic").Include(

                "~/Content/css/animate.css/animate.min.css",
                "~/Content/css/glyphicons/glyphicons.css",
                "~/Content/css/font-awesome/css/font-awesome.min.css",
                "~/Content/css/material-design-icons/material-design-icons.css",
                "~/Content/css/bootstrap/dist/css/bootstrap.min.css",
                "~/Content/css/styles/app.css",
                "~/Content/css/styles/style.css",
                "~/Content/css/styles/font.css",
                "~/Content/libs/owl.carousel/dist/assets/owl.carousel.min.css",
                "~/Content/libs/owl.carousel/dist/assets/owl.theme.css",
                "~/Content/libs/mediaelement/build/mediaelementplayer.min.css",
                "~/Content/libs/mediaelement/build/mep.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/JSYandexMusic").Include(

            "~/Scripts/libs/jquery/dist/jquery.js",
            "~/Scripts/libs/tether/dist/js/tether.min.js",
            "~/Scripts/libs/bootstrap/dist/js/bootstrap.js",
            "~/Scripts/libs/jQuery-Storage-API/jquery.storageapi.min.js",
            "~/Scripts/libs/jquery.stellar/jquery.stellar.min.js",
            "~/Scripts/libs/owl.carousel/dist/owl.carousel.min.js",
            "~/Scripts/libs/jscroll/jquery.jscroll.min.js",
            "~/Scripts/libs/PACE/pace.min.js",
            "~/Scripts/libs/jquery-pjax/jquery.pjax.js",
            "~/Scripts/libs/mediaelement/build/mediaelement-and-player.min.js",
            "~/Scripts/libs/mediaelement/build/mep.js",
            "~/Scripts/scripts/player.js",
            "~/Scripts/scripts/config.lazyload.js",
            "~/Scripts/scripts/ui-load.js",
            "~/Scripts/scripts/ui-jp.js",
            "~/Scripts/scripts/ui-include.js",
            "~/Scripts/scripts/ui-device.js",
            "~/Scripts/scripts/ui-form.js",
            "~/Scripts/scripts/ui-nav.js",
            "~/Scripts/scripts/ui-screenfull.js",
            "~/Scripts/scripts/ui-scroll-to.js",
            "~/Scripts/scripts/ui-toggle-class.js",
            "~/Scripts/scripts/ui-taburl.js",
            "~/Scripts/scripts/app.js",
            "~/Scripts/scripts/site.js"
            //"~/Scripts/scripts/ajax.js"
            ));
        }
    }
}
