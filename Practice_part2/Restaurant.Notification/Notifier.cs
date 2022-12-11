using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Notification
{
    //for_review
    public class Notifier
    {
      
        public Notifier() { }
        public void Notify(Guid orderId, Guid clientId, string message)
        {
            Console.WriteLine($"Сообщение по заказу {orderId} - {message}");
        }

    }
}
