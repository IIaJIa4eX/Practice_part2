using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Notification
{
    //for_review
    public class Notifier
    {
        private readonly ConcurrentDictionary<Guid, Tuple<Guid?, Accepted>> _state = new();

        public void Accept(Guid orderId, Accepted accepted, Guid? clientId = null)
        {
            _state.AddOrUpdate(orderId, new Tuple<Guid?, Accepted>(clientId, accepted),
                (Guid, oldValue)=> new Tuple<Guid?, Accepted>(oldValue.Item1 ?? clientId, oldValue.Item2 | accepted));

            Notify(orderId);
        }


        private void Notify(Guid orderId)
        {
            var booking = _state[orderId];


            switch (booking.Item2)
            {

                case Accepted.All:
                    Console.WriteLine($"{orderId} - Успех! id клиента - {booking.Item1}");
                    _state.Remove(orderId, out _);
                    break;

                case Accepted.Kitchen:
                    Console.WriteLine($"{orderId} - Кухня готова принять заказ");
                    break;

                case Accepted.Booking:
                    Console.WriteLine($"{orderId} - Есть свободные столики");
                    break;

                case Accepted.Rejected:
                    Console.WriteLine($"{orderId}  - Заказ невозможно принять кухня занята или столиков нет");
                    _state.Remove(orderId, out _);
                    break;

                case Accepted.RejectedBooking:
                    Console.WriteLine($"{orderId}  - Заказ невозможно принять столиков нет");
                    break;

                case Accepted.RejectedKitchen:
                    Console.WriteLine($"{orderId}  - Заказ невозможно принять кухня занята");
                    break;

                default:
                    Console.WriteLine("Что-то пошло не так");
                    break;
            }
        }

    }
}
