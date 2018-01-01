using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Lütfen Email Adresini Doldurunuz.")]
        [EmailAddress(ErrorMessage ="Email adresi olarak giriş yapınız.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password boş bırakılamaz.")]
        public string Password { get; set; }


    }
}