using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DomainYandexMusic.Entities;
using InfastructureYandexMusic.ApplicationManagers;
using InfastructureYandexMusic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PresentationYandexMusic.Models.HomeModels;
using PresentationYandexMusic.Services.Interfaces.EntitiesInterfaces;

namespace PresentationYandexMusic.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IHomePresentationService homePresentation;

        public HomeController(IHomePresentationService homePresentation)
        {
            this.homePresentation = homePresentation;
        }

        private ApplicationUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        private ApplicationRoleManager RoleManager => HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public virtual ViewResult StartPage()
        {
            return View();
        }

        [Authorize]
        public virtual ViewResult MainPage()
        {
            return View(homePresentation.GetMainViewModel(User.Identity.GetUserId()));
        }

        public virtual FileResult GetImageByName(string name)
        {
            string pathFile = Server.MapPath("~/images/" + name);
            string typeFile = "image/jpeg";

            return File(pathFile, typeFile);
        }

        [HttpGet]
        public virtual ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async virtual Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    if (user.EmailConfirmed == true)
                    {
                        var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        if (model.Persistent != null)
                        {
                            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
                        }
                        else
                        {
                            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, identity);
                        }

                        // Block UpdateTargetId and Redirect on StartPage
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Не подтвержден email");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                }
            }

            return PartialView(MVC.Home.Views.FormLogin, model);
        }

        [HttpGet]
        public virtual ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async virtual Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }

                    return PartialView(MVC.Home.Views.FormRegister, model);
                }

                if (!RoleManager.RoleExists(TypesRoles.User))
                {
                    await RoleManager.CreateAsync(new ApplicationRole() { Name = TypesRoles.User });
                }

                if (result.Succeeded)
                {
                    if (!UserManager.IsInRole(user.Id, TypesRoles.User))
                    {
                        await UserManager.AddToRoleAsync(user.Id, TypesRoles.User);
                    }

                    await UserManager.UpdateAsync(user);

                    // генерируем токен для подтверждения регистрации
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    // создаем ссылку для подтверждения
                    var callbackUrl = Url.Action(MVC.Home.ConfirmEmail(user.Id, code), protocol: Request.Url.Scheme);

                    // отправка письма
                    await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты", "Для завершения регистрации перейдите по ссылке: <a href=\"" + callbackUrl + "\">завершить регистрацию</a>");

                    return View(MVC.Home.Views.DisplayEmail);
                }
            }

            return PartialView(MVC.Home.Views.FormRegister, model);
        }

        [HttpGet]
        [Authorize]
        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction(MVC.Home.StartPage());
        }

        public virtual async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            IdentityResult result;

            if (userId == null || code == null)
            {
                return PartialView(MVC.Home.Views.Error);
            }

            try
            {
                result = await UserManager.ConfirmEmailAsync(userId, code);
            }
            catch (InvalidOperationException ioe)
            {
                ViewBag.errorMessage = ioe.Message;
                return PartialView(MVC.Home.Views.Error);
            }

            if (result.Succeeded)
            {
                return PartialView(MVC.Home.Views.ConfirmEmail);
            }

            return PartialView(MVC.Home.Views.Error);
        }
    }
}