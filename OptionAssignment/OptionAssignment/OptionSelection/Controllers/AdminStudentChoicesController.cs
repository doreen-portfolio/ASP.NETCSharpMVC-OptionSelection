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
using OptionSelection.Models;

namespace OptionSelection.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminStudentChoicesController : Controller
    {
        private OptionContext db = new OptionContext();

        public SelectList DropDownListChoices { get; set; }

        public ActionResult Index()
        {
            DropDownListChoices = new SelectList(db.Terms.ToList(), "TermCode", "Description");
            ViewBag.DropDown = DropDownListChoices;
            return View(db.Choices.ToList());
        }

        [HttpPost]
        public ActionResult Search(string DropDown)
        {
            DropDownListChoices = new SelectList(db.Terms.ToList(), "TermCode", "Description");
            ViewBag.DropDown = DropDownListChoices;
            if (DropDown == "")
            {
                return View("Index", db.Choices.ToList());
            }
            int term = Convert.ToInt32(DropDown);
            return View("Index", db.Choices.Where(c => c.TermCode == term).ToList());
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