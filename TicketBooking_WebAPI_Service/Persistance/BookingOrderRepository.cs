using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketBooking_WebAPI_Service.Models;

namespace TicketBooking_WebAPI_Service.Persistance
{
    public class BookingOrderRepository : IRepository<BookingOrder>
    {
        private TicketBookingServiceContext db;

        public BookingOrderRepository()
        {
            
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public BookingOrder Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookingOrder> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}