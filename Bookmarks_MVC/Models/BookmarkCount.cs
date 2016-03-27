using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Bookmarks_MVC.Models
{
    public class BookmarkCount
    {
        [DisplayName("Bookmark Address")]
        public string _address { get; set; }

        [DisplayName("Popularity")]
        public int _count { get; set; }

        [DisplayName("Tags")]

        public string _tags { get; set; }
    }
}