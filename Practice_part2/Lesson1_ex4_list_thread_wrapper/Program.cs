using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lesson1_ex4_list_thread_wrapper
{

    public class Container<T> where T : class
    {
        public List<T> _list;
        public Container()
        {
            _list = new List<T>();
        }


        public void Add(T item)
        {
            lock (_list)
            {
                Console.WriteLine($"Добавляем {item}");
                _list.Add(item);
             }
        }
        
        public void Remove(T item)
        {
            lock (_list)
            {
                Console.WriteLine($"Удаляем {item}");
                _list.Remove(item);
            }
        }

        public List<T> GetList()
        {
            lock (_list)
            {
                return _list.ToList();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Container<string> stringList = new Container<string>();

            Console.WriteLine("Hello World!");
            Thread thread1 = new Thread(() =>
            {


                        for (int i = 0; i < 10; i++)
                        {
                            stringList.Add($"Значение {i}");

                        }

                
            });
            thread1.Name = "#Test1";
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
 
                        for (int i = 0; i < 10; i++)
                        {
                            stringList.Remove($"Значение {i}");

                        }   
 
            });
            thread2.Name = "#Test2";
            thread2.Start();



                foreach (string item in stringList.GetList())
                {
                Console.WriteLine($"Элемент на текущий момент {item}");
                }
            
            Console.ReadKey();
        }
    }
}
