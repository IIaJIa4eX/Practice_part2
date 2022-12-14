using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeShittyCompany.DAL.DBConnect;
using TimeShittyCompany.DAL.Interfaces;
using TimeShittyCompany.DAL.Repositories;
using TimeShittyCompany.Repositories;
using TimeShittyCompany.Services;
using TimeShittyCompany.Services.Interfaces;
using TimeShittyCompany.Services.Validation;
using TimeShittyCompany.Services.Validation.Interfaces;
using TimeShittyCompany.Utils;

namespace TimeShittyCompany
{
    //for review
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<DBConnection>();
            services.AddSingleton<IUsersRepository,UsersRepository>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<IEmployeesRepository, EmployeesRepository>();
            services.AddSingleton<IEmployeesService, EmployeesService>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserValidationService, UserValidationService>();
            services.AddCors();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new
                    TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthService.secretWord)),
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeShittyCompany", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new
                OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme(Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement{{new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,Id = "Bearer"}}
                    ,Array.Empty<string>()}
                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeShittyCompany v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
