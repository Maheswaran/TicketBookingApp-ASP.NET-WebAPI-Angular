using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TicketBooking_WebAPI_Service.Models;

namespace TicketBooking_WebAPI_Service.Controllers
{
 
    public class BookingOrdersController : ApiController
    {
        private TicketBookingServiceContext db = new TicketBookingServiceContext();

        // GET: api/BookingOrders
        public IQueryable<BookingOrder> GetBookingOrders()
        {
            return db.BookingOrders;
        }

        // GET: api/BookingOrders/5
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> GetBookingOrder(long id)
        {
            BookingOrder bookingOrder = await db.BookingOrders.FindAsync(id);
            if (bookingOrder == null)
            {
                return NotFound();
            }

            return Ok(bookingOrder);
        }

        // PUT: api/BookingOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookingOrder(long id, BookingOrder bookingOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookingOrder.OrderID)
            {
                return BadRequest();
            }

            db.Entry(bookingOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingOrderExists(id))
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

        // POST: api/BookingOrders
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> PostBookingOrder(BookingOrder bookingOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookingOrders.Add(bookingOrder);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bookingOrder.OrderID }, bookingOrder);
        }

        // DELETE: api/BookingOrders/5
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> DeleteBookingOrder(long id)
        {
            BookingOrder bookingOrder = await db.BookingOrders.FindAsync(id);
            if (bookingOrder == null)
            {
                return NotFound();
            }

            db.BookingOrders.Remove(bookingOrder);
            await db.SaveChangesAsync();

            return Ok(bookingOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingOrderExists(long id)
        {
            return db.BookingOrders.Count(e => e.OrderID == id) > 0;
        }
    }
}