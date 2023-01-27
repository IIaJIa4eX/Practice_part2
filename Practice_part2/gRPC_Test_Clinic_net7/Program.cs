using gRPC_Test_DataBase_Clinic;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Grpc.JsonTranscoding;
using gRPC_Test_Clinic_net7.Services;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Google.Api;

namespace gRPC_Test_Clinic_net7
{
    //for_review

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); //First step: This step about webapp configuration(services, etc...)


            //Http protocols configuration
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 5001, listenOptions =>
                {
                    listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
                });

                options.Listen(IPAddress.Any, 5002, listenOptions =>
                {
                    listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1;
                });

            });



            builder.Services.AddSignalR();
            builder.Services.AddGrpc();

            //Transoding Http to Grpc format
            builder.Services
                .AddGrpc()
                .AddJsonTranscoding();


            // Add services to the container.
            builder.Services.AddAuthorization();



            builder.Services.AddDbContext<ClinicDataBaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["Settings:DataBaseOptions:ConnectionString"]);
            });


            
            builder.Services.AddGrpcSwagger();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "gRPC Clinic", Version = "v1" });
                //To make it works simply add <GenerateDocumentationFile>true</GenerateDocumentationFile> to project settings.
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "gRPC_Test_Clinic_net7.xml");//Name is same as Project's name
                c.IncludeXmlComments(filePath);
                c.IncludeGrpcXmlComments(filePath, includeControllerXmlComments: true);
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "SignalR", Version = "v1" });
                // some other configs
                options.AddSignalRSwaggerGen();
            });

            var app = builder.Build();//Second step: This is my webapp after First step, this step about requests managing.


            if (app.Environment.IsDevelopment())//gets from launchSettings.json (ASPNETCORE_ENVIRONMENT)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            

            // Configure the HTTP request pipeline.

            //allows to manage requests
            app.UseRouting();


            app.MapHub<SignalR_Hub>("info");

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled= true });

            app.MapGrpcService<ClinicService>().EnableGrpcWeb();


            app.MapGet("/", () =>
            "You need to create grps client to communicate with me"
            );

            app.Run();
        }
    }
}