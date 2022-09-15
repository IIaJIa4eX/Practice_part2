using System;
using System.Collections.Generic;

namespace lesson_3_patterns_part2
{
    class Program
    {
        public interface IGood
        {
            Good GetGood(string url);
            IReadOnlyList<Good> GetGoods(string url);

        }

        public class Good 
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
