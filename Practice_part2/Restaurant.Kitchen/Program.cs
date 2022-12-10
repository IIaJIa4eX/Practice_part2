using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Kitchen.Consumers;

namespace Restaurant.Kitchen
{
    //for_review
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateHostBuilder(args).Build().Run();

        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<KitchenTableBookedConsumer>();
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("kebnekaise-01.lmq.cloudamqp.com", 5671, "lnvntukf", conf =>
                        {
                            conf.Username("lnvntukf");
                            conf.Password("hveU4zUk4FFJSYmzvSds3d9XxPZVYV9L");

                            //ForSSl Port 5671
                            conf.UseSsl(s =>
                            {
                                s.Protocol = System.Security.Authentication.SslProtocols.Tls12;
                            });

                        });

                        cfg.ConfigureEndpoints(context);

                    });
                });
                services.AddTransient<Manager>();
            });
    }
}
