using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TicketBooking_WebAPI_Service.Models;

namespace TicketBooking_WebAPI_Service.Controllers
{    
    [EnableCorsAttribute("http://localhost:4200", "*", "Get")]
    public class UsersController : ApiController
    {
        private TicketBookingServiceContext db = new TicketBookingServiceContext();

        [HttpGet]
        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            return Ok(db.Users);
        }

        [HttpGet]
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(long id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [DisableCors]
        [HttpPut]
        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(long id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpPost]
        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        [HttpDelete]
        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult Delete(long id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(long id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}