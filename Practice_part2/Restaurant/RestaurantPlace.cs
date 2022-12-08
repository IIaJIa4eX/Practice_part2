using Messaging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    //for review
    public class RestaurantPlace
    {
        private readonly List<Table> _tables = new();
        private SendMessage _message = new();

        
        public RestaurantPlace()
        {
            for (int i = 1; i <= 10; i++)
            {
                _tables.Add(new Table(i));
            }
        }

        public void BookFreeTable(int personsCount)
        {

            Console.WriteLine("Подождите, подмираем столик синхронно..");
            var table = _tables.FirstOrDefault(t => t.SeatsCount > personsCount && t.state == State.Free);

            Thread.Sleep(1000 * 5);

            if(table is null)
            {
                Console.WriteLine("Простите, столов нет");
            }
            else
            {
                table?.SetState(State.Booked);
                Console.WriteLine($"Готово! столик номер {table.Id}");
            }
        }

        public async Task<bool?> BookFreeTableAsync(int personsCount)
        {
            Console.WriteLine("Подождите, подмираем столик асинхронно..");

            
                var table = _tables.FirstOrDefault(t => t.SeatsCount > personsCount && t.state == State.Free);


                await Task.Delay(1000 * 5);
                return table?.SetState(State.Booked);
            
        }

        public void UnBookTable(int tableId)
        {
            Console.WriteLine("Подождите, отменяем бронь синхронно..");
            var table = _tables.FirstOrDefault(t => t.Id == tableId && t.state == State.Booked);

            Thread.Sleep(1000 * 5);
            
            if (table is null)
            {
                Console.WriteLine("Такого стола не существует или он не забронирован");
            }
            else
            {
                table?.SetState(State.Free);
                Console.WriteLine($"Готово! столик номер {table.Id} снят с брони");
            }
        }

        public void UnBookTableAsync(int tableId)
        {
            Console.WriteLine("Подождите, отменяем бронь асинхронно..");
            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.Id == tableId && t.state == State.Booked);

                await Task.Delay(1000 * 5);

                if (table is null)
                {
                    _message.SendMessageAsync("смс - Такого стола не существует или он не забронирован");
                }
                else
                {
                    table?.SetState(State.Free);
                    _message.SendMessageAsync($" смс - Готово! столик номер {table.Id} снят с брони");
                }
            });
        }

        public void UnbookAllTables()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(4000 * 5);
                    foreach (var table in _tables)
                    {
                        table.SetState(State.Free);
                    }
                    Console.WriteLine("Все столы разбронирвоаны");
                }
            });
        }
    }
}
