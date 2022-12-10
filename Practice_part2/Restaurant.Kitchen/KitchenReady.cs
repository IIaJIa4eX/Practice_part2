using Restaurant.Kitchen.Inerfaces;

namespace Restaurant.Kitchen
{
    internal class KitchenReady : IKitchenReady
    {
        public Guid OrderId { get; set; }
        public bool isReady { get; set; }

        public KitchenReady(Guid orderId, bool isReady)
        {
            this.OrderId = orderId;
            this.isReady = isReady;
        }
    }
}
