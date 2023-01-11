using MassTransit;
using Restaurant.Kitchen.Inerfaces;
using Restaurant.Messages;

namespace Restaurant.Kitchen
{
    //for_review
    public class Manager
    {
        private readonly IBus _bus;

        public Manager(IBus bus)
        {
            _bus = bus;
        }

        public void CheckKitchenReady(Guid orderId, Dish? dish)
        {
            Random s = new Random();
            int rand = s.Next(0, 2);
            _bus.Publish<IKitchenReady>(new KitchenReady(orderId, rand == 0 ? false : true));
        }
    }
}
