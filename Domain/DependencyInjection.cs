using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services, string databaseConnection)
    {
       
        // ADD SQL
        services.AddDbContext<FacilityReportContext>(options => options.UseSqlServer(databaseConnection));

        return services;
    }
}
