using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Models.ORM.Entity
{
    public class AdminUser : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}