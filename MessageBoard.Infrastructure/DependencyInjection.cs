using MessageBoard.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }

}
