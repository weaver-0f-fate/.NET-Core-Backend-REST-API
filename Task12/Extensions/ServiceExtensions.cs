using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Task12.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services) {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServiceWrapper(this IServiceCollection services) {
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
        }
    }
}
