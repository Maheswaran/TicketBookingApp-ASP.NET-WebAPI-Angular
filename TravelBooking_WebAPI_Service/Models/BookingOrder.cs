using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketBooking_WebAPI_Service.Models
{

    public enum TravelType
    {
        Flight,
        Bus,
        Train,
        Cab
    }

    public class Location 
    {
        [Required]
        public string City { get; set; }

        public string State { get; set; }

        public string BoardingAddress { get; set; }

        public long PinCode { get; set; }

    }

    public class BookingOrder
    {  
        [Key]
        public long OrderID { get; set; }

        public string UserID { get; set; }

        public string OrderStatus { get; set; }

        public double OrderAmount { get; set; }

        public TravelType TravelBy { get; set; }

        public Location Source { get; set; }

        public Location Destination { get; set; }
    }
}