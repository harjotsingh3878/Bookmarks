using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookmarks_MVC.Models
{
    public class Bookmark
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }

        public string Tags { get; set; }

        [DisplayName("Public")]

        public bool IsPublic { get; set; }



        public virtual ApplicationUser User { get; set;}
    }
}