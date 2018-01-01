using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Models.ORM.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}