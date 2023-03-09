using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Booking;
using Restaurant.Booking.Consumers;
using Restaurant.Messages.Interfaces;
using Restaurant.Messages;
using NUnit.Framework;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MassTransit.RabbitMqTransport;

namespace Restaurant.Tests
{
    //for__review
    public class ConsumerTests
    {

        private ServiceProvider _provider;
        private ITestHarness _harness;

        [OneTimeSetUp]
        public async Task Init()
        {
            _provider  = new ServiceCollection().AddMassTransitTestHarness(cfg =>
            {
                cfg.AddConsumer<RestaurantBookingRequestConsumer>();
            }).AddLogging()
            .AddTransient<RestaurantPlace>()
            .AddSingleton<IInMemoryRepository<BookingRequestModel>, InMemoryRepository<BookingRequestModel>>()
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
        public async Task Any_booking_request_consumed()
        {
            await _harness.Bus.Publish(new BookingRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now));

            Assert.That(await _harness.Consumed.Any<IBookingRequest>());
            await _harness.OutputTimeline(TestContext.Out, options => options.Now().IncludeAddress());
        }


        [Test]
        public async Task Booking_request_consumer_published_table_booked_message()
        {

            var consumer = _provider.GetRequiredService <IConsumerTestHarness<RestaurantBookingRequestConsumer>>();
            var orderId = NewId.NextGuid();

            var bus = _provider.GetRequiredService<IBus>();

            await bus.Publish<IBookingRequest>(new BookingRequest(orderId,orderId,DateTime.Now));

            Assert.That(consumer.Consumed.Select<IBookingRequest>()
            .Any(x => x.Context.Message.OrderId == orderId), Is.True);

            Assert.That(_harness.Published.Select<ITableBooked>()
            .Any(x => x.Context.Message.OrderId == orderId), Is.True);

            await _harness.OutputTimeline(TestContext.Out, options => options.Now().IncludeAddress());
        }
    }
}