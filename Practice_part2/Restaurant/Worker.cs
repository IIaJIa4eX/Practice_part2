using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
                Console.WriteLine("К сожалению, вы можете только асинхронно забронировать столик");
                await _place.BookFreeTableAsync(1);
            }
        }

        
    }
}
