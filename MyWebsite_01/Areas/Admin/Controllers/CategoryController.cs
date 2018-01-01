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
    public class CategoryController : Controller
    {
        BlogContext db = new BlogContext();

        // GET: Admin/Category
        public ActionResult Index()
        {

            List<CategoryVM> model = db.Category.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).Select(x => new CategoryVM()
            {
                Name = x.Name,
                Description = x.Description,
                Id = x.Id
            }).ToList();

            return View(model);
        }

        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryVM category)
        {
            if (ModelState.IsValid)
            {
                Category cat = new Category();
                cat.Name = category.Name;
                cat.Description = category.Description;

                db.Category.Add(cat);
                db.SaveChanges();
                //basarılı veya basarısız olduğunu uyarı olarak yukarıda cıkartır...
                ViewBag.IslemDurumu = 1;

                return View();
            }
            else
            {
                //basarılı veya basarısız olduğunu uyarı olarak yukarıda cıkartır...
                ViewBag.IslemDurumu = 0;

                return View();
            }
            
        }

        public JsonResult DeleteCategory(int id)
        {

            Category cat = db.Category.FirstOrDefault(x => x.Id == id);
            cat.isDeleted = true;
            cat.DeleteDate = DateTime.Now;

            db.SaveChanges();

            return Json("");
        }
    }

}