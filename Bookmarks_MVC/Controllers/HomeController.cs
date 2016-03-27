using Bookmarks_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks_MVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET : Public Bookmarks
         public ActionResult Bookmarks()
        {
            ViewBag.Message = "Bookmarks Page";

            var query = db.Bookmarks
                .GroupBy(q => new { q.Address })
                .Select(x => new BookmarkCount()
                {
                    _address = x.Key.Address,
                    _count= x.Count()

                    //_tags = x.Key.Tags

                })
                .OrderByDescending(x => x._count);

            return View(query.ToList());

        }

    }
}