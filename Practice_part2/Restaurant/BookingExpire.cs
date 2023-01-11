using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Booking.Interfaces;

namespace Restaurant.Booking
{
    //for__review
    public class BookingExpire : IBookingExpire
    {
        private readonly RestaurantBooking _instance;
        public BookingExpire(RestaurantBooking restaurant )
        {
            _instance = restaurant;
        }

        public Guid OrderId => _instance.OrderId;
    }
}
