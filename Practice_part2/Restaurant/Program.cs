using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace Restaurant
{
    internal class Program
    {
      

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new RestaurantPlace();
            rest.UnbookAllTables();

            while (true) {
                Console.WriteLine("Как желаете забронировать столик? \n1- по смс(асинхоонно)\n2-в порядке очереди(синхронно)\n3 - снять бронь синхронно\n4- снять бронь асинхронно");

                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
                {
                    Console.WriteLine("Введите 1, 2, 3, 4");
                    continue;
                }

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                if (choice == 1)
                {
                    rest.BookFreeTableAsync(1);
                }
                if(choice == 2)
                {
                    rest.BookFreeTable(1);
                }
                if (choice == 3)
                {
                    Console.WriteLine("Ведите id стола");
                    if (!int.TryParse(Console.ReadLine(), out var tableId))
                    {
                        Console.WriteLine("Введите числовой айди стола!");
                        continue;
                    }
                    rest.UnBookTable(tableId);
                }
                if (choice == 4)
                {
                    Console.WriteLine("Ведите id стола");
                    if (!int.TryParse(Console.ReadLine(), out var tableId))
                    {
                        Console.WriteLine("Введите числовой айди стола!");
                        continue;
                    }
                    rest.UnBookTableAsync(tableId);
                }

                Console.WriteLine("Спасибо за Ваше обращение");
                stopWatch.Stop();
                TimeSpan elapsed = stopWatch.Elapsed;
                Console.WriteLine($"{elapsed.Seconds:00}:{elapsed.Milliseconds:00}");
            }
        }
    }
}