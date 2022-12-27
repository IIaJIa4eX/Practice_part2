using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Booking;
using Restaurant.Messages.Interfaces;
using Restaurant.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using Restaurant.Booking.Consumers;
using Restaurant.Kitchen.Inerfaces;

namespace Restaurant.Tests
{
    //for__review
    public class Saga
    {
        private ServiceProvider _provider;
        private ITestHarness _harness;

        [OneTimeSetUp]
        public async Task Init()
        {
            _provider = new ServiceCollection().AddMassTransitTestHarness(cfg =>
            {
                cfg.AddConsumer<RestaurantBookingRequestConsumer>();
                cfg.AddSagaStateMachine<RestaurantBookingSaga, RestaurantBooking>().Endpoint(e => e.Temporary = true)
                .InMemoryRepository();
                cfg.AddSagaStateMachineTestHarness<RestaurantBookingSaga, RestaurantBooking>();
                cfg.AddDelayedMessageScheduler();


            }).AddLogging()
            .AddTransient<RestaurantPlace>()
            .AddSingleton<IInMemoryRepository<BookingRequestModel>, InMemoryRepository<BookingRequestModel>>()
            .AddTransient<RestaurantBooking>()
            .AddTransient<RestaurantBookingSaga>()
            .AddHostedService<Worker>()
            .BuildServiceProvider(true);

            _harness = _provider.GetTestHarness();

            await _harness.Start();
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _harness.OutputTimeline(TestContext.Out, options => options.Now().IncludeAddress());
            await _provider.DisposeAsync();
        }


        [Test]
        public async Task Should_be_easy()
        {
            var orderId = NewId.NextGuid();
            var clientId = NewId.NextGuid();

            await _harness.Bus.Publish(new BookingRequest(orderId, clientId, DateTime.Now));
            Assert.That(await _harness.Published.Any<IBookingRequest>());
            Assert.That(await _harness.Consumed.Any<IBookingRequest>());

            var sagaHarness = _provider.GetRequiredService<IStateMachineSagaTestHarness<RestaurantBooking, RestaurantBookingSaga>>();

            Assert.That(await sagaHarness.Consumed.Any<IBookingRequest>());
            Assert.That(await sagaHarness.Created.Any(x => x.CorrelationId == orderId));

            var saga = sagaHarness.Created.Contains(orderId);

            Assert.That(saga, Is.Not.Null);
            Assert.That(saga.ClientId, Is.EqualTo(clientId));
            Assert.That(await _harness.Published.Any<ITableBooked>());
            //Assert.That(await _harness.Published.Any<IKitchenReady>());
            //Assert.That(await _harness.Published.Any<INotify>());

            await _harness.OutputTimeline(TestContext.Out, configure: options => options.Now().IncludeAddress());
        }
    }
}
