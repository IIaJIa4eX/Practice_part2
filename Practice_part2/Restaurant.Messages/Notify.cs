using Restaurant.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Messages
{
    public class Notify : INotify
    {
        public Guid OrderId { get; set; }

        public Guid ClientId { get; set; }

        public string Message { get; set; }

        public Notify(Guid orderId, Guid clientId, string message)
        {
            OrderId = orderId;
            ClientId = clientId;
            Message = message;
        }
    }
}
