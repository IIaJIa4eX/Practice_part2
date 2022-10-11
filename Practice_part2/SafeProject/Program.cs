using Microsoft.EntityFrameworkCore;
using SafeProject.Services.Interfaces;
using SafeProject.Services.Repositories;
using SafeProjectDBLib;

namespace SafeProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<CardStorageDbConnection>(options =>
            {
                
                options.UseSqlServer(builder.Configuration["Settings:DataBaseOptions:ConnectionString"]);
            });

            builder.Services.AddScoped<ICardRepositoryService, CardRepository>();
            builder.Services.AddScoped<IClientRepositoryService, ClientRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}