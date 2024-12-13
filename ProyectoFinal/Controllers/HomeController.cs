using Newtonsoft.Json;
using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorizationService _authService = new AuthorizationService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(Usuarios model)
        {
            string returnUrl = Url.Action("Index", "Home");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            Usuarios users = new Usuarios();
            var result = _authService.Auth(model.Usuario, model.Pass, out Usuarios user);
            switch (result)
            {
                case AuthResults.Success:
                    CookieUpdate(user);
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                case AuthResults.PasswordNotMatch:
                    TempData["AlertMessage"] = "La Contrasena es incorrecta.";
                    return RedirectToAction("Index", "Home");
                case AuthResults.NotExists:
                    TempData["AlertMessage"] = "El usuario no existe.";
                    return RedirectToAction("Index", "Home");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult LogoutPartial()
        {
            return PartialView("LogoutPartial");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0)]
        [ValidateAntiForgeryToken]
        public ActionResult RefreshLogin(Login model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { Message = "" }, JsonRequestBehavior.AllowGet);
            }
            Usuarios users = new Usuarios(); ;
            var result = _authService.Auth(model.Usuario, model.Pass, out Usuarios user);
            switch (result)
            {
                case AuthResults.Success:
                    CookieUpdate(user);
                    return Json(new { Message = "Cookies Refrescados Correctamente." }, JsonRequestBehavior.AllowGet);
                case AuthResults.PasswordNotMatch:
                    return Json(new { Message = "La contraseña no es valida." }, JsonRequestBehavior.AllowGet);
                case AuthResults.NotExists:
                    return Json(new { Message = "El usuario no es valido." }, JsonRequestBehavior.AllowGet);
                default:
                    return Json(new { Message = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }

        private void CookieUpdate(Usuarios user)
        {
            var ticket = new FormsAuthenticationTicket(2,
                user.Usuario,
                DateTime.Now,
                DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                false,
                JsonConvert.SerializeObject(user)
            );
            Session["Username"] = user.Usuario;
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)) { };
            Response.AppendCookie(cookie);
        }
    }
}