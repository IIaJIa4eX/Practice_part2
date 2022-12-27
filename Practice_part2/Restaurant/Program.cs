using MassTransit;
using MassTransit.Audit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Booking;
using Restaurant.Booking.Consumers;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Restaurant
{
    //for_review
    public sealed class Program
    {
      

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateHostBuilder(args).Build().Run();
             
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webuilder =>
            {
                webuilder.UseStartup<Startup>();
            });

    }
}