using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Areas.Admin.Models.Attributes
{
    public class SessionManager
    {
        public static AdminUser CurrentUser 
        {
            get { return HttpContext.Current.Session["AdminUser"] as AdminUser; }
            set { HttpContext.Current.Session.Add("AdminUser", value); }
        }
        public static void RemoveCurrent()
        {
            HttpContext.Current.Session.Remove("AdminUser");
        }


    }
}