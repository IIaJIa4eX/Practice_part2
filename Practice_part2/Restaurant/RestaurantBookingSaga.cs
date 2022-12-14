using MassTransit;
using Restaurant.Kitchen.Inerfaces;
using Restaurant.Messages;
using Restaurant.Messages.Interfaces;
using Restaurant.Notification;
using System.Net.Mime;

namespace Restaurant.Booking
{
    public sealed class RestaurantBookingSaga : MassTransitStateMachine<RestaurantBooking>
    {
        public MassTransit.State AwaitingBookingApproved { get; private set; }
        public Event<IBookingRequest> BookingRequested { get; private set; }

        public Event<ITableBooked> TableBooked { get; private set; }

        public Event<IKitchenReady> KitchenReady { get; private set; }

        public Schedule<RestaurantBooking, IBookingExpire> BookingExpired { get; private set; } 

        public Event BookinApproved { get; private set; }

        public Event<Fault<IBookingRequest>> BookingRequestFault { get; private set; }

        public RestaurantBookingSaga()
        {
            InstanceState(x => x.CurrentState);

            Event(() => BookingRequested,
                x => x.CorrelateById(context => context.Message.OrderId)
                .SelectId(context => context.Message.OrderId));

            Event(() => TableBooked,
                x => x.CorrelateById(context => context.Message.OrderId));

            Event(() => KitchenReady,
                x => x.CorrelateById(context => context.Message.OrderId));

            Event(() => BookingRequestFault,
                x => x.CorrelateById(context => context.Message.Message.OrderId));

            CompositeEvent(() => BookinApproved,
                x => x.ReadyEventStatus, KitchenReady, TableBooked);


            Schedule(() => BookingExpired,
                x => x.ExpirationId,
                x =>
                {
                    x.Delay = TimeSpan.FromSeconds(5);
                    x.Received = e => e.CorrelateById(context => context.Message.OrderId);
                });

            Initially(
                When(BookingRequested).Then(context =>
                {
                    context.Instance.CorrelationId = context.Data.OrderId;
                    context.Instance.OrderId = context.Data.OrderId;
                    context.Instance.ClientId = context.Data.ClientId;
                    Console.WriteLine("Saga: создание заказа" + context.Data.CreationDate);
                })
                .Schedule(BookingExpired,
                 context => new BookingExpire (context.Instance),
                 context => TimeSpan.FromSeconds(6)).TransitionTo(AwaitingBookingApproved)
                );

            During(AwaitingBookingApproved, When(BookinApproved)
                .Unschedule(BookingExpired)
                .Publish(context =>
                (INotify)new Notify(context.Instance.OrderId,
                                    context.Instance.ClientId,
                                    "Стол успешно забронирован"))
                .Finalize(),

                When(BookingRequestFault).Then(context => Console.WriteLine("Ошибка брони"))
                .Publish(context => (INotify)new Notify(
                    context.Instance.OrderId,
                    context.Instance.ClientId,
                    "Не получилось забронировать стол"))
                .Publish(context => (IBookingCancellation)
                    new BookingCancellation(context.Instance))
                .Finalize(),

                When(BookingExpired.Received)
                .Then(context => Console.WriteLine($"Отмена заказа {context.Instance.OrderId}"))
                .Finalize()
                );

            SetCompletedWhenFinalized();


        }
    }
}
