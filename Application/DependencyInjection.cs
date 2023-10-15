using Application.Repository;
using Application.Repository.RepositoryImp;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDJRepository(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepositoryImp>();
            services.AddScoped<IEquiptmentRepository, EquiptmentRepositoryImp>();
            services.AddScoped<IFeedbackRepository, FeedbackRepositoryImp>();
            services.AddScoped<IHistoryEquipmentRepository, HistoryEquipmentRepositoryImp>();
            services.AddScoped<IImageRepository, IImageRepository>();
            services.AddScoped<IPostRepository, PostRepositoryImp>();
            services.AddScoped<IResourceRepository, ResourceRepositoryImp>();
            services.AddScoped<ITaskRepository, TaskRepositoryImp>();
            return services;
        }
    }
}
