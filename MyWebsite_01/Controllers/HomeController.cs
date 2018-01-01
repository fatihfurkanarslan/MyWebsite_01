using MyWebsite_01.Models.ORM.Context;
using MyWebsite_01.Models.ORM.Entity;
using MyWebsite_01.Models.ORM.VM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_01.Controllers
{
    public class HomeController : Controller
    {

        BlogContext db = new BlogContext();
        // GET: Home
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult Resume()
        {
            //List<FrontBlogPostVM> model = db.BlogPost.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).Select(x => new FrontBlogPostVM()
            //{
            //    Title = x.Title,
            //    Content = x.Content,
            // //CategoryName = x.Category.Name

            //}).ToList();

            FrontBlogPostVM model = new FrontBlogPostVM();
            model.BlogPosts = db.BlogPost.Where(p=>!p.isDeleted).ToList();
            model.Categories = db.Category.Where(c=>!c.isDeleted).ToList();



            return View(model);
        }

        public ActionResult Projects()
        {
            FrontBlogPostVM model = new FrontBlogPostVM();
            model.BlogPosts = db.BlogPost.Where(p => !p.isDeleted).ToList();
            model.Categories = db.Category.Where(c => !c.isDeleted).ToList();
            return View(model);
        }

        public ActionResult Contact()
        {

          

            return View();

        }

        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            MailMessage _mm = new MailMessage();

            _mm.SubjectEncoding = Encoding.Default;
            _mm.Subject = model.AdiSoyadi;
            _mm.BodyEncoding = Encoding.Default;
            _mm.Body = model.Mesaj;

            _mm.From = new MailAddress(ConfigurationManager.AppSettings["emailAccount"]);
            _mm.To.Add("arslanfatihfurkan@gmail.com");


            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.Host = ConfigurationManager.AppSettings["emailHost"];
            _smtpClient.Port = int.Parse(ConfigurationManager.AppSettings["emailPort"]);
            _smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailAccount"], ConfigurationManager.AppSettings["emailPassword"]);
            _smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["emailSLLEnable"]);

            _smtpClient.Send(_mm);

            TempData["Basarili"] = "Teşekürler en kısa zamanda tafarınıza dönüş yapılacaktır.";

            return RedirectToAction("Contact");
        }

   
    }
}