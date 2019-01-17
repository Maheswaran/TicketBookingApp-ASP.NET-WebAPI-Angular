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
using TicketBooking_WebAPI_Service.Persistance;

namespace TicketBooking_WebAPI_Service.Controllers
{
    //public class BookingOrdersController : ApiController
    //{
    //    public BookingOrderRepository bookingOrderRepository;

    //    public BookingOrdersController()
    //    {
    //        bookingOrderRepository = new BookingOrderRepository();
    //    }

    //    // GET: api/BookingOrders
    //    public IEnumerable<BookingOrder> GetBookingOrders()
    //    {
    //        return bookingOrderRepository.GetAll();
    //    }

    //    // GET: api/BookingOrders/5
    //    [ResponseType(typeof(BookingOrder))]
    //    public async Task<IHttpActionResult> GetBookingOrder(int id)
    //    {
    //        BookingOrder bookingOrder = await bookingOrderRepository.GetBy(id);
    //        if (bookingOrder == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(bookingOrder);
    //    }

    //    // PUT: api/BookingOrders/5
    //    [ResponseType(typeof(void))]
    //    public async Task<IHttpActionResult> PutBookingOrder(long id, BookingOrder bookingOrder)
    //    {
    //        try
    //        {

    //            if (!ModelState.IsValid)
    //            {
    //                return BadRequest(ModelState);
    //            }

    //            if (!BookingOrderExists(id))
    //            {
    //                return NotFound();
    //            }

    //            if (id != bookingOrder.OrderID)
    //            {
    //                return BadRequest();
    //            }

    //            await bookingOrderRepository.UpdateAsync(bookingOrder);

    //            return StatusCode(HttpStatusCode.NoContent);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    // POST: api/BookingOrders
    //    [ResponseType(typeof(BookingOrder))]
    //    public async Task<IHttpActionResult> PostBookingOrder(BookingOrder bookingOrder)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        int response = await bookingOrderRepository.AddAsync(bookingOrder);
    //        return CreatedAtRoute("DefaultApi", new { id = bookingOrder.OrderID }, bookingOrder);
    //    }

    //    // DELETE: api/BookingOrders/5
    //    [ResponseType(typeof(BookingOrder))]
    //    public async Task<IHttpActionResult> DeleteBookingOrder(long id)
    //    {
    //        //BookingOrder bookingOrder = await db.BookingOrders.FindAsync(id);
    //        BookingOrder bookingOrder = bookingOrderRepository.GetBy(id).Result;
    //        if (bookingOrder == null)
    //        {
    //            return NotFound();
    //        }

    //        int response = await bookingOrderRepository.DeleteAsync(bookingOrder);
    //        return Ok(response);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            bookingOrderRepository.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool BookingOrderExists(long id)
    //    {
    //        return bookingOrderRepository.GetAll(x => x.OrderID == id).Count() > 0;
    //        //return db.BookingOrders.Count(e => e.OrderID == id) > 0;
    //    }
    //}


    public class BookingOrdersController : ApiController
    {
        public BookingOrderRepository bookingOrderRepository;

        public BookingOrdersController(IRepository<BookingOrder> repository)
        {
            bookingOrderRepository = (BookingOrderRepository)repository;
        }

        // GET: api/BookingOrders
        public IEnumerable<BookingOrder> GetBookingOrders()
        {
            return bookingOrderRepository.GetAll();
        }

        // GET: api/BookingOrders/5
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> GetBookingOrder(int id)
        {
            BookingOrder bookingOrder = await bookingOrderRepository.GetBy(id);
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
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!BookingOrderExists(id))
                {
                    return NotFound();
                }

                if (id != bookingOrder.OrderID)
                {
                    return BadRequest();
                }

                await bookingOrderRepository.UpdateAsync(bookingOrder);

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/BookingOrders
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> PostBookingOrder(BookingOrder bookingOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int response = await bookingOrderRepository.AddAsync(bookingOrder);
            return CreatedAtRoute("DefaultApi", new { id = bookingOrder.OrderID }, bookingOrder);
        }

        // DELETE: api/BookingOrders/5
        [ResponseType(typeof(BookingOrder))]
        public async Task<IHttpActionResult> DeleteBookingOrder(long id)
        {
            //BookingOrder bookingOrder = await db.BookingOrders.FindAsync(id);
            BookingOrder bookingOrder = bookingOrderRepository.GetBy(id).Result;
            if (bookingOrder == null)
            {
                return NotFound();
            }

            int response = await bookingOrderRepository.DeleteAsync(bookingOrder);
            return Ok(response);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bookingOrderRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingOrderExists(long id)
        {
            return bookingOrderRepository.GetAll(x => x.OrderID == id).Count() > 0;
            //return db.BookingOrders.Count(e => e.OrderID == id) > 0;
        }
    }
}