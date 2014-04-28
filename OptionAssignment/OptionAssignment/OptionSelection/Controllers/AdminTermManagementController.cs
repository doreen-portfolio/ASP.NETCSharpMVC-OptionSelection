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
    public class AdminTermManagementController : Controller
    {
        private OptionContext db = new OptionContext();

        public ActionResult Index()
        {
            return View(db.Terms.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TermCode,Description,IsActive")] Term term)
        {
            if (ModelState.IsValid)
            {
                var existingTerm = db.Terms.Find(term.TermCode);
                if(existingTerm == null)
                {
                    db.Terms.Add(term);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "A term with that term code already exists";
            }

            return View(term);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View(term);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TermCode,Description,IsActive")] Term term)
        {
            if (ModelState.IsValid)
            {
                if (term.IsActive)
                {
                    if (db.Terms.Where(t => t.IsActive).Count() > 0)
                    {
                        ViewBag.Error = "Only one Term can be active! You must deacivate another term.";
                        return View(term);
                    }
                }
                db.Entry(term).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(term);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return HttpNotFound();
            }
            return View(term);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Term term = db.Terms.Find(id);
            db.Terms.Remove(term);
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
