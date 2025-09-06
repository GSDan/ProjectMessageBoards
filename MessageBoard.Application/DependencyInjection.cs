using MessageBoard.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddInfrastructureLayer();

            return services;
        }
    }
}
