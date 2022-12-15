using MassTransit;
using Restaurant.Kitchen.Inerfaces;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;


namespace Restaurant.Booking.Consumers
{
    //for__review
    public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
    {
        private readonly RestaurantPlace _restaurant;

        public RestaurantBookingRequestConsumer(RestaurantPlace restaurant)
        {
            _restaurant = restaurant;
        }

        public async Task Consume(ConsumeContext<IBookingRequest> context)
        {
            Console.WriteLine($"Заказ прилетел {context.Message.OrderId}");

            var result = await _restaurant.BookFreeTableAsync(1);

            await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, context.Message.ClientId, result ?? false));
        }
    }
}
