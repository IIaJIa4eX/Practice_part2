using System;
using System.Collections.Generic;

namespace lesson_3_patterns_part2
{
    class Program
    {


        public abstract class CommonGoodsLogic
        {

            public abstract void GetGood(string url);

            public abstract void GetGoods(string url);



        }

        public abstract class CommonGoodInfo
        {

        }

        public class FirstGoodStructure : CommonGoodInfo
        {
            public int Id { get; set; }
            public int price { get; set; }
            public string name { get; set; }
        }


        public class FisrtGoodHanlder : CommonGoodsLogic
        {
            FirstGoodStructure first;
            IReadOnlyList<FirstGoodStructure> goodList;
            public override void GetGood(string url)
            {
                //get good info from webService
                first = new() { Id = 1, name = "name", price = 12434 };

                Console.WriteLine($"{first.Id} {first.name} {first.price}");
            }

            public override void GetGoods(string url)
            {
                //get goods info from webService
                goodList = new List<FirstGoodStructure>()
                {
                    new FirstGoodStructure(){ Id = 1, name = "name", price = 12434},
                    new FirstGoodStructure(){ Id = 2, name = "name2", price = 11111},
                    new FirstGoodStructure(){ Id = 3, name = "name3", price = 122222}
                };
                foreach(FirstGoodStructure item in goodList)
                {
                    Console.WriteLine($"{item.Id} {item.name} {item.price}");
                }

            }
        }




        static void Main(string[] args)
        {
            FisrtGoodHanlder fist = new FisrtGoodHanlder();
            fist.GetGood("https");
            fist.GetGoods("https");


            Console.WriteLine("Hello World!");
        }
    }
}
