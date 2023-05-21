﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NewUpstorm.Data.IRepositories;
using NewUpstorm.Data.Repositories;
using NewUpstorm.Service.Interfaces;
using NewUpstorm.Service.Services;
using System.Reflection;

namespace NewUpstorm.Web.Extensions
{
    public static class ServiceExtentions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IForecastService, ForecastService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "New-upstorm.api", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Version}.xml";

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType .SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                        }
                });
            });
        }
    }
}
