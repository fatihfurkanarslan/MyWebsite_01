using MyWebsite_01.Areas.Admin.Models.Attributes;
using MyWebsite_01.Areas.Admin.Models.DTO;
using MyWebsite_01.Models.ORM.Context;
using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_01.Areas.Admin.Controllers
{


    [LoginControl]
    public class BlogPostController : Controller
    {

        BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            List<BlogPostVM> model = db.BlogPost.Where(x => x.isDeleted == false).Select(x => new BlogPostVM
            {
                Title = x.Title,
                Content = x.Content,
                CategoryName = x.Category.Name,
                Id = x.Id              
            }).ToList();

            return View(model);
        }
        // GET: Admin/BlogPost
        public ActionResult AddBlogPost()
        {
            BlogPostVM blogPost = new BlogPostVM();
          //  List<Category> posts = db.Category.ToList();


            blogPost.drpCategories = db.Category.Where(x=> x.isDeleted == false).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
       


            return View(blogPost);
        }


        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model)
        {

            model.drpCategories = db.Category.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            if (ModelState.IsValid)
            {

                BlogPost post = new BlogPost();
                post.CategoryId = model.CategoryId;
                post.Title = model.Title;
                post.Content = model.Content;

                db.BlogPost.Add(post);
                db.SaveChanges();

                ViewBag.IslemDurumu = 1;

                

                return View(model);
            }
            else
            {
                ViewBag.IslemDurumu = 0;
                return View(model);
            }

            
        }


        public JsonResult DeleteBlogPost(int id)
        {

            BlogPost blog = db.BlogPost.FirstOrDefault(x => x.Id == id);
            blog.isDeleted = true;
            blog.DeleteDate = DateTime.Now;

            db.SaveChanges();

            return Json("");
        }
    }

    
}