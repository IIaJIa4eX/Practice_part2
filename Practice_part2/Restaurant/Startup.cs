using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Messages.Interfaces;
using Restaurant.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Audit;
using Restaurant.Booking.Consumers;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Prometheus;

namespace Restaurant.Booking
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMassTransit(x =>
            {
                services.AddSingleton<IMessageAuditStore, AuditStore>();

                var serviceprovider = services.BuildServiceProvider();

                var auditstore = serviceprovider.GetService<IMessageAuditStore>();
                //new
                x.AddConsumer<RestaurantBookingRequestConsumer>(conf =>
                     conf.UseMessageRetry(retry =>

                            retry.Incremental(2, TimeSpan.FromSeconds(1),
                            TimeSpan.FromSeconds(2)))
                     )
                .Endpoint(e =>
                {
                    e.Temporary = true;
                });

                x.AddConsumer<BookingRequestFaultConsumer>()
                .Endpoint(e =>
                {
                    e.Temporary = true;
                });

                x.AddSagaStateMachine<RestaurantBookingSaga, RestaurantBooking>().Endpoint(e => e.Temporary = true)
                .InMemoryRepository();
                x.AddSagaStateMachineTestHarness<RestaurantBookingSaga,RestaurantBooking>();

                x.AddDelayedMessageScheduler();



                x.UsingRabbitMq((context, cfg) =>
                {

                    cfg.UsePrometheusMetrics(serviceName: "booking_service");
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


                    cfg.UseDelayedMessageScheduler();
                    cfg.UseInMemoryOutbox();
                    cfg.ConfigureEndpoints(context);

                    cfg.ConnectSendAuditObservers(auditstore);
                    cfg.ConnectConsumeAuditObserver(auditstore);
                });
            });


            //не используется в последних версиях
            //services.AddMassTransitHostedService(true)();

            services.AddTransient<RestaurantBooking>();
            services.AddTransient<RestaurantBookingSaga>();
            services.AddSingleton<RestaurantPlace>();
            services.AddSingleton<IInMemoryRepository<BookingRequestModel>, InMemoryRepository<BookingRequestModel>>();
            services.AddHostedService<Worker>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMetrics();
                endpoints.MapControllers();
            });
        }
    }
}
