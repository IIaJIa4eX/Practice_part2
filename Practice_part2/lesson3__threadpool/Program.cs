using System;
using System.Threading;
using System.Threading.Tasks;

namespace lesson3__threadpool
{

    public class PoolSettings
    {
        public int _maxThreads { get; private set; }
        public PoolSettings(int maxThreads)
        {           
            _maxThreads = maxThreads;
        }



    }

    public class TestPool
    {

        PoolSettings _pullControll;

        public TestPool(int maxThreads)
        {
            _pullControll = new PoolSettings(maxThreads);

        }

        public void  DoStuff(WaitCallback callback)
        {          
                if (ThreadPool.ThreadCount < _pullControll._maxThreads)
                {
                     ThreadPool.QueueUserWorkItem(callback, _pullControll);
                        Console.WriteLine($"Кол-во потоков{ThreadPool.ThreadCount}");
                }
                else
                {
                    throw new Exception("To much threads to use");
                }
            
        }


}


    class Program
    {
        static  void Main(string[] args)
        {
            //TestPool test = new TestPool(1);
            TestPool test = new TestPool(5);

            for (int  i = 0; i < 9; i++)
            {
                try
                {
                     test.DoStuff(new WaitCallback(SomeHighLoadCalculation));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            Console.ReadKey();
        }


        public static void SomeHighLoadCalculation(object state)
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Thread.Sleep(1000);

        }



    }
}
