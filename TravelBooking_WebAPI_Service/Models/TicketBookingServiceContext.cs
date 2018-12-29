using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TicketBooking_WebAPI_Service.Models
{
    public class TicketBookingServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TicketBookingServiceContext() : base("name=TicketBookingServiceContext")
        {
        }

        public System.Data.Entity.DbSet<TicketBooking_WebAPI_Service.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<TicketBooking_WebAPI_Service.Models.BookingOrder> BookingOrders { get; set; }
    }
}
