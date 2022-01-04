using BlogAspnetCursombanagouro.Models.FormModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(ContactFormModel model)
        {
            new MailerController().Contact(model).Deliver();
            return View();
        }
    }
}