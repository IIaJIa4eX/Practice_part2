using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using DataBaseDAL;
using MarketProject.AutofacGroupServices;
using MarketProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketProject.Models;
using MarketProject.Extensions;

namespace MarketProject
{
    //for_review

    class AutoFacContainer
    {

        private static IHost? _host;

        public static IHost Hosting => _host ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        static async Task Main(string[] args)
        {
            var host = Hosting;
            //await host.StartAsync();
           // await AddNewProduct();
            await PrintBuyersAsync();
           // await host.StopAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
       .CreateDefaultBuilder(args)
       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(container => {

           container.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
           container.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
           //container.RegisterType<ProductService>().InstancePerLifetimeScope()
           //container.RegisterModule<ServiceModule>();
           //container.RegisterAssemblyModules(Assembly.GetCallingAssembly()); - Reflection, searching for all Modules


           //Autofac.Configuration
           //var config = new ConfigurationBuilder();

           // config.AddJsonFile("autofac.config.json");//Creating Json



           //var module = new ConfigurationModule(config.Build());
           //var builder = new ContainerBuilder();
           //builder.RegisterModule(module);

       }
       )
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


        private static async Task AddNewProduct()
        {
            await using var servicesScope = Services.CreateAsyncScope();
            var services = servicesScope.ServiceProvider;

            var productsService = services.GetRequiredService<IProductService>();

           
            await productsService.AddAsync(222500, "Electronics", "TV SAMSUNG 777");
            await productsService.AddAsync(222500, "Electronics", "Xiomy 45g");
            await productsService.AddAsync(222500, "Electronics", "ASUS OverPrice 999");

        }

        private static async Task PrintBuyersAsync()
        {
            await using (var servicesScope = Services.CreateAsyncScope())
            {
                var services = servicesScope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<OrdersDbContext>();

                await context.Database.MigrateAsync();

                foreach (var buyer in context.Buyers)
                {
                    logger.LogInformation($"Покупатель >>> {buyer.Id} {buyer.LastName} {buyer.Name} {buyer.Patronymic} {buyer.Birthday.ToShortDateString()}");
                }

                var orderService = services.GetRequiredService<IOrderService>();


                await orderService.CreateAsync(1, "Tula, Russia", "+88005553535", new (int, int)[] {
                    new ValueTuple<int, int>(1, 1)
                });


                var catalog = new OrderTemplateModel
                {
                    OrderNumber = "8467034",
                    CreationDate = DateTime.Now,
                    Products = context.Products
                };

                string templateFile = "Templates/DefaultTemplate.docx";
                IOrderInfo report = new OrderInfo(templateFile);

                CreateReport(report, catalog, "Report.docx");

                Console.ReadKey(true);
            }
        }


        private static void CreateReport(IOrderInfo reportGenerator, OrderTemplateModel catalog, string reportFileName)
        {
            reportGenerator.OrderNumber = catalog.OrderNumber;
            reportGenerator.CreationDate = catalog.CreationDate;
            reportGenerator.Products = catalog.Products.Select(product => (product.Id, product.Name, product.Category, product.Price));

            var reportFileInfo = reportGenerator.Create(reportFileName);
            reportFileInfo.Execute();
        }




    }
}
