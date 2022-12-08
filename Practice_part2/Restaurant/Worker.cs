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

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
