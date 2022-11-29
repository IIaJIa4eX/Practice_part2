using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var rest = new RestaurantPlace();
            while (true) {
                Console.WriteLine("Как желаете забронировать столик? \n1- по смс(асинхоонно)\n2-в порядке очереди(синхронно) ");

                if (!int.TryParse(Console.ReadLine(), out var choice) && choice is not (1 or 2))
                {
                    Console.WriteLine("Введите 1 или 2");
                    continue;
                }

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                if (choice == 1)
                {
                    rest.BookFreeTableAsync(1);
                }
                else
                {
                    rest.BookFreeTable(1);
                }

                Console.WriteLine("Спасибо за Ваше обращение");
                stopWatch.Stop();
                TimeSpan elapsed = stopWatch.Elapsed;
                Console.WriteLine($"{elapsed.Seconds:00}:{elapsed.Milliseconds:00}");
            }
        }
    }
}