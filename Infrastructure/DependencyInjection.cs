using Infrastructure.IUnitofwork.Unitofwork;
using Infrastructure.IUnitofwork;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.IService;
using Infrastructure.IService.ServiceImplement;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Mapper;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Domain.Entity;
using Infrastructure.Common.SecurityService;
using Infrastructure.Common.SecurityService.Imp;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDJService(this IServiceCollection services, string databaseConnection)
        {
            // SERVICE
            services.AddScoped<IUnitofWork, Unitofwork>();

            services.AddTransient<IAccountService, AccountServiceImp>();
            services.AddTransient<IEquipmentService, EquipmentServiceImp>();
            services.AddTransient<IFeedbackService, FeedbackServiceImp>();
            services.AddTransient<IHistoryEquipmentService, HistoryEquipmentServiceImp>();
            services.AddTransient<IImageService, ImageServiceImp>();
            services.AddTransient<IJobService, JobServiceImp>();
            services.AddTransient<IPostService, PostServiceImp>();
            services.AddTransient<IReService, ResourceServiceImp>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokensHandler, TokensHandler>();

            // ADD SQL
            services.AddDbContext<FacilityReportContext>(options => options.UseSqlServer(databaseConnection));
            services.AddAutoMapper(typeof(ApplicationMapper).Assembly);


            return services;
        }
        public static IServiceCollection AddDJJWT(this IServiceCollection services, string JWTSecretKey, string Issuer, string Audience)
        {
            // AUTHENTICATION
            var secretKeyBytes = Encoding.UTF8.GetBytes(JWTSecretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(jwtBearerOptions =>
           {
               jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Issuer,
                   ValidAudience = Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                   ClockSkew = TimeSpan.Zero
               };
           });

            //services.AddAuthorization();

            services.AddMemoryCache();
            //CORS

            return services;
        }
    }
}
