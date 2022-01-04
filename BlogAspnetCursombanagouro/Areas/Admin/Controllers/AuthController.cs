using BlogAspnetCursombanagouro.Application;
using BlogAspnetCursombanagouro.Areas.Admin.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogAspnetCursombanagouro.Areas.Admin.Controllers
{
    public class AuthController : AdminController
    {
        [AllowAnonymous]
        public ActionResult LogOn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Admin.Dashboard.Index");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOn(LogOnModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                FormsAuthentication.SetAuthCookie("Admin", false);
                if (!String.IsNullOrWhiteSpace(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                return RedirectToRoute("Admin.Dashboard.Index");
            }
            else
            {
                ViewBag.Fail = true;
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Admin.Auth.LogOn");
        }
    }
}