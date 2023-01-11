using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;
using System.Text;

namespace Restaurant.Booking
{
    //for__review
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
                Console.WriteLine("Клиент пытается забронироват стол и сделать заказ");
                //Console.ReadKey();

                //var result = await _place.BookFreeTableAsync(1);

                await _bus.Publish(new BookingRequest(NewId.NextGuid(), NewId.NextGuid(), DateTime.UtcNow), stoppingToken);

            }
        }

        
    }
}
