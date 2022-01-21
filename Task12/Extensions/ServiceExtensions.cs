using Core.Models;
using Data.Interfaces;
using Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Services.DataTransferObjects.OperationDTOs;
using Services.Interfaces;
using Services.Services;
using Task12.FluentValidator;

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

        public static void ConfigureFluentValidator(this IServiceCollection services) {
            services.AddFluentValidation();
            services.AddTransient<IValidator<OperationForCreateDTO>, OperationForCreateDtoValidator>();
            services.AddTransient<IValidator<OperationForUpdateDTO>, OperationForUpdateDtoValidator>();
        }
    }
}
