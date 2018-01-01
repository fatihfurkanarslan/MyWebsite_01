using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Models.ORM.Entity
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}