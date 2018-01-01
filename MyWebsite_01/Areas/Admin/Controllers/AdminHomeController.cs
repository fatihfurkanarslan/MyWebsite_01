using MyWebsite_01.Areas.Admin.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_01.Areas.Admin.Controllers
{
    [LoginControl]
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome

        public ActionResult Index()
        {
            return View();
        }
    }
}