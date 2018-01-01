using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Models.ORM.VM
{
    public class FrontBlogPostVM
    {

        //public string Title { get; set; }

        //public string Content { get; set; }

        //public string CategoryName { get; set; }

        public List<Category> Categories  { get; set; }

        public List<BlogPost> BlogPosts { get; set; }



    }
}