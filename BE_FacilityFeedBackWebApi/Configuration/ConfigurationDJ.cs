using BE_FacilityFeedBackWebApi.Middlewares;
using Domain.Enum;
using Infrastructure;
using Infrastructure.Common;
using Microsoft.OpenApi.Models;
using System.Diagnostics;

namespace BE_FacilityFeedBackWebApi.Configuration
{
    public static class ConfigurationDJ
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var appConfiguration = configuration.GetSection("ConnectString").Get<AppConfiguration>();
            var jwt = configuration.GetSection("JWT").Get<JWToken>();

            services.AddDJJWT(jwt.JWTSecretKey, jwt.Issuer, jwt.Audience);
            services.AddSingleton(jwt);

            services.AddDJService(appConfiguration.DatabaseConnection);
            services.AddSingleton(appConfiguration);
            services.AddDJSwagger();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // ADD MIDDLEWARE
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddSingleton<Stopwatch>();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSignalR();
            return services;
        }
        public static IServiceCollection AddDJSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebFacilityReport.WebApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            // ALLOW HTTP
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin() // You can also specify specific origins here instead of allowing any origin.
                           .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
