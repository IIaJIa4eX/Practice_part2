using Messaging;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Notification
{
    //for_review
    public class Worker : BackgroundService
    {
        private readonly Consumer _consumer;



        public Worker()
        {
            _consumer = new Consumer("BookingNotification", "kebnekaise-01.lmq.cloudamqp.com");
        }
        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Receive((sender, args) =>
            {
                byte[] body = args.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                Console.WriteLine("::: Получено {0}", message);
            });
        }
    }
}
