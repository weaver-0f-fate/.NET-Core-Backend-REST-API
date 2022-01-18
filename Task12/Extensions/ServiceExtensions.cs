using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Task12.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
