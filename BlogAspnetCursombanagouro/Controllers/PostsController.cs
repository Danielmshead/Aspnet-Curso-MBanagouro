using BlogAspnetCursombanagouro.Application;
using BlogAspnetCursombanagouro.Data;
using BlogAspnetCursombanagouro.Models;
using BlogAspnetCursombanagouro.Models.Entities;
using BlogAspnetCursombanagouro.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace BlogAspnetCursombanagouro.Controllers
{
    public class PostsController : Controller
    {
        [OutputCache(CacheProfile = "OneMinute")]
        public ActionResult GetAll(PagingOptions pagingOptions)
        {
            var context = new BlogContext();

            var model = context.Posts
                .Include(x => x.Category)
                .OrderByDescending(x => x.PublishedOn)
                .ToPagedList(pagingOptions.Page, pagingOptions.Size);

            return View("List", model);
        }

        [OutputCache(CacheProfile = "OneMinute")]
        public ActionResult GetByCategory(string category, PagingOptions pagingOptions)
        {
            var context = new BlogContext();

            if (String.IsNullOrWhiteSpace(category))
            {
                return GetAll(pagingOptions);
            }

            var model = context.Posts
                .Include(x => x.Category)
                .Where(x => x.Category.Permalink == category)
                .OrderByDescending(x => x.PublishedOn)
                .ToPagedList(pagingOptions.Page, pagingOptions.Size);

            return View("List", model);
        }

        [OutputCache(CacheProfile = "OneMinute")]
        public ActionResult Search(string term, PagingOptions pagingOptions)
        {
            var context = new BlogContext();

            if (String.IsNullOrWhiteSpace(term))
            {
                return GetAll(pagingOptions);
            }

            var model = context.Posts
                .Include(x => x.Category)
                .Where(x =>
                    x.Title.Contains(term) ||
                    x.Summary.Contains(term) ||
                    x.Content.Contains(term)
                )
                .OrderByDescending(x => x.PublishedOn)
                .ToPagedList(pagingOptions.Page, pagingOptions.Size);

            return View("List", model);
        }

        public ActionResult Details(string permalink)
        {
            var cache = MemoryCache.Default;
            var cacheKey = "post-" + permalink;

            PostDetail model = cache.Get(cacheKey) as PostDetail;
            if (model == null)
            {
                var context = new BlogContext();

                var query = (from p in context.Posts
                             .Include(x => x.Category)
                             where p.Permalink == permalink
                             select new PostDetail
                             {
                                 Post = p,
                                 TotalComments = p.Comments.Count
                             });

                model = query.FirstOrDefault();

                if (model == null)
                {
                    return HttpNotFound();
                }

                var item = new CacheItem(cacheKey, model);
                var policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTime.Now.AddMinutes(10);
                cache.Add(item, policy);
            }

            return View(model);
        }

        public ActionResult LoadComments(string permalink, PagingOptions pagingOptions)
        {
            var context = new BlogContext();

            pagingOptions.Size = 5; 

            var model = context.Comments
                .Where(x => x.Post.Permalink == permalink)
                .OrderByDescending(x => x.PublishedOn)
                .ToPagedList(pagingOptions.Page, pagingOptions.Size);

            return PartialView("_Comments", model);
        }

        [HttpPost]
        public ActionResult AddComment(int postId, Comment comment)
        {
            var context = new BlogContext();

            comment.Post = context.Posts.Find(postId);
            context.Comments.Add(comment);
            context.SaveChanges();

            MemoryCache.Default.Remove("post-" + comment.Post.Permalink);

            return RedirectToAction("Details", new { permalink = comment.Post.Permalink });
        }
    }
}