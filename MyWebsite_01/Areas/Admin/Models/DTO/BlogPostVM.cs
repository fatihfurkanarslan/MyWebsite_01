using MyWebsite_01.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_01.Areas.Admin.Models.DTO
{
    public class BlogPostVM : BaseVM
    {
        [Required(ErrorMessage ="Boş bırakılamaz")]
        public string Title { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<SelectListItem> drpCategories { get; set; }


    }
}