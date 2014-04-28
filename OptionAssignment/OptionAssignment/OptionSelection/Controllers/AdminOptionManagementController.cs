using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptionClassLibrary.Models;
using OptionSelection.DataContext;

namespace OptionSelection.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminOptionManagementController : Controller
    {
        private OptionContext db = new OptionContext();

        public ActionResult Index()
        {
            return View(db.Options.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Title,IsActive")] Option option)
        {
            if (ModelState.IsValid)
            {
                var existingOption = db.Options.Find(option.Title);
                if(existingOption == null)
                {
                    db.Options.Add(option);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "There is already an option with that name";
            }
            return View(option);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Title,IsActive")] Option option)
        {
            if (ModelState.IsValid)
            {
                db.Entry(option).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(option);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Option option = db.Options.Find(id);
            db.Options.Remove(option);
            db.SaveChanges();
            return RedirectToAction("Index");
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
