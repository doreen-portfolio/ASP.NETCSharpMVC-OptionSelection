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
    public class TermController : ApiController
    {
        private OptionContext db = new OptionContext();

        // GET api/Term
        public IQueryable<Term> GetTerms()
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            return db.Terms;
        }

        // GET api/Term/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult GetTerm(int id)
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            return Ok(term);
        }

        // PUT api/Term/5
        public IHttpActionResult PutTerm(int id, Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != term.TermCode)
            {
                return BadRequest();
            }

            db.Entry(term).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermExists(id))
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

        // POST api/Term
        [ResponseType(typeof(Term))]
        public IHttpActionResult PostTerm(Term term)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Terms.Add(term);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TermExists(term.TermCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = term.TermCode }, term);
        }

        // DELETE api/Term/5
        [ResponseType(typeof(Term))]
        public IHttpActionResult DeleteTerm(int id)
        {
            Term term = db.Terms.Find(id);
            if (term == null)
            {
                return NotFound();
            }

            db.Terms.Remove(term);
            db.SaveChanges();

            return Ok(term);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermExists(int id)
        {
            return db.Terms.Count(e => e.TermCode == id) > 0;
        }
    }
}