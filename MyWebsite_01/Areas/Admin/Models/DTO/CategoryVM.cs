using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Areas.Admin.Models.DTO
{
    public class CategoryVM : BaseVM
    {
        [Required(ErrorMessage ="boş geçmeyiniz")]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Display(Description="Açıklama")]
        public string Description { get; set; }

    }
}