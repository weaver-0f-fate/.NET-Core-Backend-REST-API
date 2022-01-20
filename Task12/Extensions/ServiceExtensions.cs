using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;

namespace Task12.Extensions {
    public static class ServiceExtensions {
        public static void ConfigureRepositories(this IServiceCollection services) {
            services.AddTransient<IOperationsRepository, OperationsRepository>();
            services.AddTransient<IOperationTypesRepository, OperationTypesRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services) {
            services.AddTransient<IOperationsService, OperationsService>();
            services.AddTransient<IOperationTypesService, OperationTypesService>();
        }
    }
}
