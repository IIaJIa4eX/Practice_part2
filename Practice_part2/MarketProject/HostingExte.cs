using DataBaseDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject
{
    class HostingExte
    {

        private static IHost? _host;

        public static IHost Hosting => _host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        static async Task Main(string[] args)
        {
            var host = Hosting;
            await host.StartAsync();
            await PrintBuyersAsync();
            Console.ReadKey(true);
            await host.StopAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
       .CreateDefaultBuilder(args)
       .ConfigureHostConfiguration(options =>
           options.AddJsonFile("appsettings.json"))
       .ConfigureAppConfiguration(options =>
           options
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .AddCommandLine(args)).ConfigureLogging(options =>
                options.ClearProviders() // Microsoft.Extensions.Logging
                    .AddConsole()
                    .AddDebug())
                .ConfigureServices(ConfigureServices);
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {

            services.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlServer(host.Configuration["Settings:DataBase:ConnectionString"]);
            });

            
        }

        public static IServiceProvider Services
        {
            get
            {
                return Hosting.Services;
            }
            //OR another way
            // public static IServiceProvider Services => Hosting.Services;
        }


        private static async Task PrintBuyersAsync()
        {
            await using var servicesScope = Services.CreateAsyncScope();
            var services = servicesScope.ServiceProvider;

            var context = services.GetRequiredService<OrdersDbContext>();
            var logger = services.GetRequiredService<ILogger<HostingExte>>();

            foreach (var buyer in context.Buyers)
            {
                logger.LogInformation($"Покупатель >>> {buyer.LastName} {buyer.Name} {buyer.Patronymic} {buyer.Birthday.ToShortDateString()}");
            }
        }


    }
}
