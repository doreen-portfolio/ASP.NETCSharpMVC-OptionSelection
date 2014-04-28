using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OptionClassLibrary.Models;
using OptionSelection.DataContext;

namespace OptionSelection.Controllers
{
    public class ChoiceController : ApiController
    {
        private OptionContext db = new OptionContext();

        // GET api/Choice
        public IQueryable<Choice> GetChoices()
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            return db.Choices;
        }

        // GET api/Choice/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult GetChoice(int id)
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            return Ok(choice);
        }

        // PUT api/Choice/5
        public IHttpActionResult PutChoice(int id, Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != choice.ChoiceId)
            {
                return BadRequest();
            }

            db.Entry(choice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Choice
        [ResponseType(typeof(Choice))]
        public IHttpActionResult PostChoice(Choice choice)
        {
            choice.CreateDate = DateTime.Now;

            Term q = (from t in db.Terms where t.TermCode == choice.TermCode select t).FirstOrDefault();
            choice.Term = q;

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var p = from c in db.Choices select c.StudentNumber;

            if (p.Contains(choice.StudentNumber))
            {
                return BadRequest(ModelState);
            }

            db.Choices.Add(choice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = choice.ChoiceId }, choice);
        }

        // DELETE api/Choice/5
        [ResponseType(typeof(Choice))]
        public IHttpActionResult DeleteChoice(int id)
        {
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return NotFound();
            }

            db.Choices.Remove(choice);
            db.SaveChanges();

            return Ok(choice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChoiceExists(int id)
        {
            return db.Choices.Count(e => e.ChoiceId == id) > 0;
        }
    }
}