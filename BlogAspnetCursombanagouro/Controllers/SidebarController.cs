using BlogAspnetCursombanagouro.Data;
using BlogAspnetCursombanagouro.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Controllers
{
    public class SidebarController : Controller
    {
        // GET: Sidebar
        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            var context = new BlogContext();

            var model = from c in context.Categories
                         select new CategoryItem
                         {
                             Name = c.Name,
                             Permalink = c.Permalink,
                             PostCount = c.Posts.Count()
                         };

            return PartialView("_Categories", model);
        }
    }
}