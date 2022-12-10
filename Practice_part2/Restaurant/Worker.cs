using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;
using System.Text;

namespace Restaurant.Booking
{
    public class Worker : BackgroundService
    {
        private readonly IBus _bus;
        private readonly RestaurantPlace _place;


        public Worker(IBus bus, RestaurantPlace place)
        {
            _bus = bus;
            _place = place;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
                Console.WriteLine("К сожалению, вы можете только асинхронно забронировать столик, нажмите что-нибудь чтобы забронировать");
                Console.ReadKey();

                var result = await _place.BookFreeTableAsync(1);

                await _bus.Publish(new TableBooked(NewId.NextGuid(), NewId.NextGuid(), result ?? false),
                    context => context.Durable = false, stoppingToken);

            }
        }

        
    }
}
