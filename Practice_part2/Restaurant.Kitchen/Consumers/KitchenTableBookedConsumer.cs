using MassTransit;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Kitchen.Consumers
{
    //for__review
    public class KitchenTableBookedConsumer : IConsumer<IBookingRequest>
    {

        public readonly Manager _manager;


        public KitchenTableBookedConsumer(Manager manager)
        {
            _manager = manager;
        }
        public Task Consume(ConsumeContext<IBookingRequest> context)
        {
            var rnd = new Random().Next(1000, 10000);

            if(rnd > 6000) {
                throw new Exception($"Заказ не может обрабатываться так долго! - {context.Message.OrderId}");
            }

            Console.WriteLine($"Проверка на кухне займёт{rnd}");
            Task.Delay( rnd );

             _manager.CheckKitchenReady(context.Message.OrderId,null);

            return context.ConsumeCompleted;
        }
    }
}
