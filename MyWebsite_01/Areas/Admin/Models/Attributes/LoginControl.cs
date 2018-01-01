using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_01.Areas.Admin.Models.Attributes
{
    public class LoginControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionManager.CurrentUser == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
            }
        }

    }
}