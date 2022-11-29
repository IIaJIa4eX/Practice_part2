using final_project.DAL;
using final_project.DAL.Entities;
using final_project.Services;
using static final_project.DAL.Entities.User;

namespace final_project
{
    //For_Review

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<DBConnection>();
            builder.Services.AddScoped<IUserServiceRepository, UserServiceRepository>();
            //CreateUsers();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }


        public static void CreateUsers()
        {
            DBConnection context = new DBConnection();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Иван",
                    LastName = "Иванов",
                    Patronymic = "Иванович",
                    Email = "test@mail.com"
                });
                context.Users.Add(new User
                {
                    LastName = "Huan",
                    Name = "Jamel",
                    Patronymic = "Korokko",
                    Email = "test2@mail.com"
                });


                context.SaveChanges();
            }
            Console.WriteLine(context.Users.FirstOrDefault().Email);
        }
    }
}