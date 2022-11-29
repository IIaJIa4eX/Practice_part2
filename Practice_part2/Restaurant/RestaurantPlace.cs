using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class RestaurantPlace
    {
        private readonly List<Table> _tables = new();

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
                Console.WriteLine($"Готово! столик номер {table.Id}");
            }
        }

        public void BookFreeTableAsync(int personsCount)
        {
            Console.WriteLine("Подождите, подмираем столик синхронно..");

            Task.Run(async () =>
            {
                var table = _tables.FirstOrDefault(t => t.SeatsCount > personsCount && t.state == State.Free);


                await Task.Delay(1000 * 5);
                table?.SetState(State.Booked);

                if (table is null)
                {
                    Console.WriteLine("смс - Простите, столов нет");
                }
                else
                {
                    Console.WriteLine($"смс - Готово! столик номер {table.Id}");
                }
            });
        }
    }
}
