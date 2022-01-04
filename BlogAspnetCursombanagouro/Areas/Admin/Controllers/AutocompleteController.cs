using BlogAspnetCursombanagouro.Application;
using BlogAspnetCursombanagouro.Data;
using System.Linq;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Areas.Admin.Controllers
{
    public class AutocompleteController : AdminController
    {
        [OutputCache(CacheProfile="OneDay")]
        public ActionResult Categories(string term)
        {
            var context = new Data.BlogContext();
            string slug = term.ToSlug();

            var model = context.Categories
                .Where(x => x.Permalink.StartsWith(slug))
                .Select(x => x.Name)
                .ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}