using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SafeProject.Services;
using SafeProject.Services.Interfaces;
using SafeProject.Services.Repositories;
using SafeProjectDBLib;
using System.Net;
using System.Text;

namespace SafeProject
{
    //for_review
    public class Program
    {//for_review
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //explicitly add http2 for gRPC
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 5002, o =>
                {
                    o.Protocols = HttpProtocols.Http2;
                    //o.UseHttps();
                });
            });

            // Add services to the container.
            builder.Services.AddGrpc();
            builder.Services.Configure<TestConfigurations>(builder.Configuration.GetSection("CardSettings"));

            builder.Services.AddDbContext<CardStorageDbConnection>(options =>
            {
                //Settings from appsettings
                options.UseSqlServer(builder.Configuration["Settings:DataBaseOptions:SQLConnectionString"]);

            });

            builder.Services.AddScoped<ICardRepositoryService, CardRepository>();
            builder.Services.AddScoped<IClientRepositoryService, ClientRepository>();
            builder.Services.AddScoped<IAccountRepsitoryService, AccountRepsitory>();

            builder.Services.AddSingleton<IAuthService, AuthService>();

            

           // builder.Services.AddAuthentication(x =>
           // {
           //     x.DefaultAuthenticateScheme =
           //     JwtBearerDefaults.AuthenticationScheme;
           //     x.DefaultChallengeScheme =
           //     JwtBearerDefaults.AuthenticationScheme;
           // })
           //.AddJwtBearer(x =>
           //{
           //    x.RequireHttpsMetadata = false;
           //    x.SaveToken = true;
           //    x.TokenValidationParameters = new
           //     TokenValidationParameters
           //    {
           //        ValidateIssuerSigningKey = true,
           //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthSettings:SecretWord"])),
           //        ValidateIssuer = false,
           //        ValidateLifetime = true,
           //        ValidateAudience = false,
           //        ClockSkew = TimeSpan.Zero
           //    };
           //});






            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SafeProject", Version = "v1" });

            //    c.AddSecurityDefinition("Bearer", new
            //    OpenApiSecurityScheme
            //    {
            //        Description = "you need to auth, man)",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    });
            //    c.AddSecurityRequirement(
            //        new OpenApiSecurityRequirement{{new OpenApiSecurityScheme{
            //        Reference = new OpenApiReference{
            //            Type = ReferenceType.SecurityScheme,Id = "Bearer"}}
            //        ,Array.Empty<string>()}
            //        });

            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
           
            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClientService>();

                endpoints.MapControllers();
            });

            app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

           

            app.Run();
        }
    }
}