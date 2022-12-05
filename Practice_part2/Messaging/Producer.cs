using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class Producer
    {
        private readonly string _queueName;
        private readonly string _hostName;

        public Producer(string queueName, string hostName)
        {
            _queueName = queueName;
            _hostName = "kebnekaise-01.lmq.cloudamqp.com";
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                Port = 5672,
                UserName = "lnvntukf",
                Password = "hveU4zUk4FFJSYmzvSds3d9XxPZVYV9L",
                VirtualHost = "lnvntukf"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare("direct_exchange", "direct", false, false, null);

            byte[] data = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "direct_exchange", routingKey: _queueName, basicProperties: null, body: data);
        }
    }
}
