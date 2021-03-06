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
namespace PresentationYandexMusic.Areas.Admin.Controllers
{
    public partial class AdminPlaylistController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AdminPlaylistController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult DeletePlaylist()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeletePlaylist);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.FileResult GetPlaylistImage()
        {
            return new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.GetPlaylistImage);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AdminPlaylistController Actions { get { return MVC.Admin.AdminPlaylist; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "AdminPlaylist";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "AdminPlaylist";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string CreatePlaylist = "CreatePlaylist";
            public readonly string FormPlaylistSuccess = "FormPlaylistSuccess";
            public readonly string DeletePlaylist = "DeletePlaylist";
            public readonly string GetPlaylistImage = "GetPlaylistImage";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string CreatePlaylist = "CreatePlaylist";
            public const string FormPlaylistSuccess = "FormPlaylistSuccess";
            public const string DeletePlaylist = "DeletePlaylist";
            public const string GetPlaylistImage = "GetPlaylistImage";
        }


        static readonly ActionParamsClass_CreatePlaylist s_params_CreatePlaylist = new ActionParamsClass_CreatePlaylist();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreatePlaylist CreatePlaylistParams { get { return s_params_CreatePlaylist; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreatePlaylist
        {
            public readonly string playlistView = "playlistView";
        }
        static readonly ActionParamsClass_DeletePlaylist s_params_DeletePlaylist = new ActionParamsClass_DeletePlaylist();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeletePlaylist DeletePlaylistParams { get { return s_params_DeletePlaylist; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeletePlaylist
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_GetPlaylistImage s_params_GetPlaylistImage = new ActionParamsClass_GetPlaylistImage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetPlaylistImage GetPlaylistImageParams { get { return s_params_GetPlaylistImage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetPlaylistImage
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
                public readonly string CreatePlaylist = "CreatePlaylist";
                public readonly string DeletePlaylist = "DeletePlaylist";
                public readonly string FormCreatePlaylist = "FormCreatePlaylist";
                public readonly string FormPlaylistSuccess = "FormPlaylistSuccess";
            }
            public readonly string CreatePlaylist = "~/Areas/Admin/Views/AdminPlaylist/CreatePlaylist.cshtml";
            public readonly string DeletePlaylist = "~/Areas/Admin/Views/AdminPlaylist/DeletePlaylist.cshtml";
            public readonly string FormCreatePlaylist = "~/Areas/Admin/Views/AdminPlaylist/FormCreatePlaylist.cshtml";
            public readonly string FormPlaylistSuccess = "~/Areas/Admin/Views/AdminPlaylist/FormPlaylistSuccess.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AdminPlaylistController : PresentationYandexMusic.Areas.Admin.Controllers.AdminPlaylistController
    {
        public T4MVC_AdminPlaylistController() : base(Dummy.Instance) { }

        [NonAction]
        partial void CreatePlaylistOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult CreatePlaylist()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.CreatePlaylist);
            CreatePlaylistOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreatePlaylistOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, PresentationYandexMusic.Areas.Admin.ViewModel.Playlist.CreatePlaylistViewModel playlistView);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreatePlaylist(PresentationYandexMusic.Areas.Admin.ViewModel.Playlist.CreatePlaylistViewModel playlistView)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreatePlaylist);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "playlistView", playlistView);
            CreatePlaylistOverride(callInfo, playlistView);
            return callInfo;
        }

        [NonAction]
        partial void FormPlaylistSuccessOverride(T4MVC_System_Web_Mvc_PartialViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.PartialViewResult FormPlaylistSuccess()
        {
            var callInfo = new T4MVC_System_Web_Mvc_PartialViewResult(Area, Name, ActionNames.FormPlaylistSuccess);
            FormPlaylistSuccessOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DeletePlaylistOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeletePlaylist(int? id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeletePlaylist);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeletePlaylistOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeletePlaylistOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeletePlaylist(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeletePlaylist);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeletePlaylistOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void GetPlaylistImageOverride(T4MVC_System_Web_Mvc_FileResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.FileResult GetPlaylistImage(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_FileResult(Area, Name, ActionNames.GetPlaylistImage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetPlaylistImageOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
