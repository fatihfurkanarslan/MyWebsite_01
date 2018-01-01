using MyWebsite_01.Areas.Admin.Models.Attributes;
using MyWebsite_01.Areas.Admin.Models.DTO;
using MyWebsite_01.Models.ORM.Context;
using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWebsite_01.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        BlogContext db = new BlogContext();

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AdminUser user = db.AdminUser.Single(x => x.Email == model.Email && x.Password == model.Password);
                if (user != null)
                {
                    SessionManager.CurrentUser = user;
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                   return View();
                }
               
            }
            else
            {
               return View();
            }

            
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            SessionManager.RemoveCurrent();
            return RedirectToAction("Login", "Login");
        }
    }

}