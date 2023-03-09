using gRPC_Test_Clinic.Services.Implementation;
using gRPC_Test_DataBase_Clinic;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace gRPC_Test_Clinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 5001, listenOptions =>
                {
                    listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                });

            });

            builder.Services.AddGrpc();
            // Add services to the container.
            builder.Services.AddDbContext<ClinicDataBaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["Settings:DataBaseOptions:ConnectionString"]);
            });
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClinicService>();
            });

            app.MapControllers();

            app.Run();
        }
    }
}