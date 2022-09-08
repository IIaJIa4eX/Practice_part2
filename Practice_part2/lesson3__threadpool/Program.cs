using System;
using System.Threading;

namespace lesson3__threadpool
{
        
    public class PoolSettings
    {
        public int _maxThreads { get; private set; }

        public int _currentThreadsCount { get; set; }
        public PoolSettings(int maxThreads)
        {
            _currentThreadsCount = 0;
            _maxThreads = maxThreads;
        }

        public bool ThreadsNumberControl()
        {
            return _currentThreadsCount <= _maxThreads;
        }
       
    }

    public  class TestPool
    {

        PoolSettings _pullControll;

        public TestPool(int maxThreads)
        {
            _pullControll = new PoolSettings(maxThreads);

        }

        public void DoStuff(WaitCallback callBack)
        {
            lock (_pullControll)
            {
                if(_pullControll.ThreadsNumberControl())
                {
                    ThreadPool.QueueUserWorkItem(callBack);
                }
                else
                {
                    throw new Exception("To much threads ot use");
                }
                
                
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            TestPool test = new TestPool(5);

            test.DoStuff(new WaitCallback(SomeHighLoadCalculation));

        }

        public static void SomeHighLoadCalculation(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(1 + i);
            }
        }
            
    }
}
