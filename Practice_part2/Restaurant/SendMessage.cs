using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    ///for review
    public class SendMessage
    {
        private readonly Producer _producer = new("BookingNotification", "kebnekaise-01.lmq.cloudamqp.com");
        public SendMessage()
        {

        }

        public void SendMessageAsync(string message)
        {
            Task.Run(async () =>
            {
                _producer.Send(message);
            });
        }

    }
}
