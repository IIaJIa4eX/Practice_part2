using DataBaseDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject
{
    class ServiceClass
    {
        static void Main(string[] args)
        {

            var serviceBuilder = new ServiceCollection();


            serviceBuilder.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlServer("data source=DESKTOP-KR7MTND\\SQLEXPRESS;initial catalog=OrdersDataBase;User Id=OrdersUser;Password=1234;MultipleActiveResultSets=True;App=EntityFramework");
            });

            //serviceBuilder.AddSingleton<IService, ServiceImplementation>();

            var serviceProvider = serviceBuilder.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<OrdersDbContext>();


            foreach (var buyer in context.Buyers)
            {
                Console.WriteLine($"{buyer.LastName} {buyer.Name} {buyer.Patronymic} {buyer.Birthday.ToShortDateString()}");
            }

            Console.ReadKey(true);


        }

           

    }
}
