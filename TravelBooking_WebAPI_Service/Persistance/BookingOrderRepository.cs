using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using TicketBooking_WebAPI_Service.Models;

namespace TicketBooking_WebAPI_Service.Persistance
{
    public class BookingOrderRepository : IRepository<BookingOrder>, IDisposable
    {     
        private TicketBookingServiceContext db = new TicketBookingServiceContext();

        public BookingOrderRepository()
        {
            
        }      

        public async Task<BookingOrder> GetBy(long id)
        {
            return await db.BookingOrders.FindAsync(id);
        }

        public IQueryable<BookingOrder> GetAll()
        {
           return db.BookingOrders;
        }

        public async Task<int> AddAsync(BookingOrder t)
        {
           db.BookingOrders.Add(t);
           return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(BookingOrder t)
        {
            db.BookingOrders.Remove(t);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(BookingOrder t)
        {
            db.Entry(t).State = EntityState.Modified;
            try
            {
              return await db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        public IQueryable<BookingOrder> GetAll(Expression<Func<BookingOrder, bool>> predicate)
        {
            if (predicate != null)
            {

               return db.BookingOrders.Where<BookingOrder>(predicate);
            }
            else
            {
                throw new ArgumentNullException("Predicate value must be passed to FindSingleBy<T>.");
            }
        }

        public void Dispose()
        {            
            GC.SuppressFinalize(db);
        }
    }
}