

using Restaurant.Booking.Interfaces;

namespace Restaurant.Booking
{
    public class BookingCancellation : IBookingCancellation
    {
        private readonly RestaurantBooking _instance;

        public BookingCancellation(RestaurantBooking instance)
        {
            _instance= instance;
        }

        public Guid OrderId => _instance.OrderId;
    }
}
