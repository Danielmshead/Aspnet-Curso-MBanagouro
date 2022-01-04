using BlogAspnetCursombanagouro.Application;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}