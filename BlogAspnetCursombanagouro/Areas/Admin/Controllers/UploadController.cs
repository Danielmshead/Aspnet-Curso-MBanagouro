using BlogAspnetCursombanagouro.Application;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        // GET: Admin/Upload
        public ActionResult Index(HttpPostedFileBase file)
        {   
            string filename = string.Concat(Path.GetRandomFileName().ToSlug(), Path.GetExtension(file.FileName));
            string filelink = new AzureBlobStorageImpl().Upload(filename, file.InputStream);

            var model = new
            {
                filelink = filelink,
                title = filename

            };

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}