using DataBaseDAL;
using DataBaseDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MarketProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersDbContext>()
                .UseSqlServer("data source=DESKTOP-KR7MTND\\SQLEXPRESS;initial catalog=OrdersDataBase;User Id=OrdersUser;Password=1234;MultipleActiveResultSets=True;App=EntityFramework");
            using (var context = new OrdersDbContext(dbContextOptionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                if (!context.Buyers.Any())
                {
                    context.Buyers.Add(new Buyer
                    {
                        LastName = "Юзеров",
                        Name = "Юзер",
                        Patronymic = "Юзерович",
                        Birthday = DateTime.Now.AddYears(-66).Date,
                    });
                    context.Buyers.Add(new Buyer
                    {
                        LastName = "Иванов",
                        Name = "Иван",
                        Patronymic = "Иванович",
                        Birthday = DateTime.Now.AddYears(-32).Date,
                    });


                    context.SaveChanges();
                }

               

            }

            Console.ReadKey();
        }
    }
}
