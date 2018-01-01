using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite_01.Models.ORM.Entity
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }


        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get
            {
                return _addDate;
            }
            set
            {
                _addDate = value;
            }
        }

        private bool _isDeleted = false;
        public bool isDeleted { get
            {
                return _isDeleted;
            } set
            {
                _isDeleted = value;
            }
        }

        public DateTime? DeleteDate { get; set; }

    }
}