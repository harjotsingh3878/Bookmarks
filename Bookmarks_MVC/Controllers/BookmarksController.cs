using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookmarks_MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookmarks_MVC.Controllers
{
    public class BookmarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private UserManager<ApplicationUser> manager;

        public BookmarksController()
        {
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Bookmarks
        public ActionResult Index(string id)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());
            
            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            // GET bookmarks for tags 
            if(id == null)
            {
                return View(db.Bookmarks.ToList().Where(b => b.User.Id == currentUser.Id));
            }
            else
            {
                return View(db.Bookmarks.ToList().Where(b => b.User.Id == currentUser.Id && b.Tags.Contains(id)));
            }
        }

      
        // GET: Bookmarks/Details/5
        public ActionResult Details(int? id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,Description,IsPublic,Tags")] Bookmark bookmark)
        {
            var currentUser = manager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                if(bookmark.Tags!=null)
                {
                    if(bookmark.Tags.Contains(','))
                    {
                        string[] tagsarr = bookmark.Tags.Split(',');
                        if (tagsarr.Count() >10)
                        {
                            ViewBag.Error = "Cannot Add more than 10 ";
                            return View(bookmark);
                        }
                    }
                    
                }
                
                bookmark.User = currentUser;
                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,Description,IsPublic,Tags")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                if (bookmark.Tags != null)
                {
                    if (bookmark.Tags.Contains(','))
                    {
                        string[] tagsarr = bookmark.Tags.Split(',');
                        if (tagsarr.Count() > 10)
                        {
                            ViewBag.Error = "Cannot Add more than 10 ";
                            return View(bookmark);
                        }
                    }
                }
                db.Entry(bookmark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookmark bookmark = db.Bookmarks.Find(id);
            if (bookmark == null)
            {
                return HttpNotFound();
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            db.Bookmarks.Remove(bookmark);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // test function ajax
        public string addTextbox()
        {
            return "test";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
