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
    public class OptionController : ApiController
    {
        private OptionContext db = new OptionContext();

        // GET api/Option
        public IQueryable<Option> GetOptions()
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            return db.Options;
        }

        // GET api/Option/5
        [ResponseType(typeof(Option))]
        public IHttpActionResult GetOption(string id)
        {
            db.Configuration.ProxyCreationEnabled = false; //i added this
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }

            return Ok(option);
        }

        // PUT api/Option/5
        public IHttpActionResult PutOption(string id, Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.Title)
            {
                return BadRequest();
            }

            db.Entry(option).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST api/Option
        [ResponseType(typeof(Option))]
        public IHttpActionResult PostOption(Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Options.Add(option);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OptionExists(option.Title))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = option.Title }, option);
        }

        // DELETE api/Option/5
        [ResponseType(typeof(Option))]
        public IHttpActionResult DeleteOption(string id)
        {
            Option option = db.Options.Find(id);
            if (option == null)
            {
                return NotFound();
            }

            db.Options.Remove(option);
            db.SaveChanges();

            return Ok(option);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OptionExists(string id)
        {
            return db.Options.Count(e => e.Title == id) > 0;
        }
    }
}