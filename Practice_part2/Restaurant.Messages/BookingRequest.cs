using Restaurant.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Messages
{
    public class BookingRequest : IBookingRequest
    {
        public Guid OrderId { get; private set; }

        public Guid ClientId { get; private set; }

        public DateTime CreationDate { get; set; }

        public BookingRequest(Guid OrderId, Guid ClientId, DateTime CreationDate)
        {
            this.OrderId = OrderId;
            this.ClientId = ClientId;
            this.CreationDate = CreationDate;
        }
    }
}
