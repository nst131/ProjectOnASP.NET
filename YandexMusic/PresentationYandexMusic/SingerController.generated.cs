// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace PresentationYandexMusic.Controllers
{
    public partial class SingerController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected SingerController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ViewResult SingerDetail()
        {
            return new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.SingerDetail);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileResult GetSingerImage()
        {
            return new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.GetSingerImage);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public SingerController Actions { get { return MVC.Singer; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Singer";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Singer";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ShowAllSingers = "ShowAllSingers";
            public readonly string SingerDetail = "SingerDetail";
            public readonly string GetSingerImage = "GetSingerImage";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ShowAllSingers = "ShowAllSingers";
            public const string SingerDetail = "SingerDetail";
            public const string GetSingerImage = "GetSingerImage";
        }


        static readonly ActionParamsClass_SingerDetail s_params_SingerDetail = new ActionParamsClass_SingerDetail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SingerDetail SingerDetailParams { get { return s_params_SingerDetail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SingerDetail
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_GetSingerImage s_params_GetSingerImage = new ActionParamsClass_GetSingerImage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetSingerImage GetSingerImageParams { get { return s_params_GetSingerImage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetSingerImage
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string ShowAllSingers = "ShowAllSingers";
                public readonly string SingerDetail = "SingerDetail";
            }
            public readonly string ShowAllSingers = "~/Views/Singer/ShowAllSingers.cshtml";
            public readonly string SingerDetail = "~/Views/Singer/SingerDetail.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_SingerController : PresentationYandexMusic.Controllers.SingerController
    {
        public T4MVC_SingerController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ShowAllSingersOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult ShowAllSingers()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.ShowAllSingers);
            ShowAllSingersOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SingerDetailOverride(T4MVC_System_Web_Mvc_ViewResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ViewResult SingerDetail(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.SingerDetail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            SingerDetailOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void GetSingerImageOverride(T4MVC_System_Web_Mvc_FileResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.FileResult GetSingerImage(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.GetSingerImage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetSingerImageOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
