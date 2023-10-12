using Application.Repository;
using Application.Repository.RepositoryImp;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDJRepository(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepositoryImp>();
            services.AddTransient<IEquiptmentRepository, EquiptmentRepositoryImp>();
            services.AddTransient<IFeedbackRepository, FeedbackRepositoryImp>();
            services.AddTransient<IHistoryEquipmentRepository, HistoryEquipmentRepositoryImp>();
            services.AddTransient<IImageRepository, IImageRepository>();
            services.AddTransient<IPostRepository, PostRepositoryImp>();
            services.AddTransient<IResourceRepository, ResourceRepositoryImp>();
            services.AddTransient<ITaskRepository, TaskRepositoryImp>();
            return services;

        }
    }
}
