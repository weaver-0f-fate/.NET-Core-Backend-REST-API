using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Interfaces;
using Services.Intrefaces;
using Services.Services;
using OperationType = Core.Models.Models.OperationType;
using Services.DataTransferObjects;
using Data.Interfaces;
using Core.Models.Models;
using Task12.Extensions;

namespace Task12 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<RepositoryContext>(options => 
                options.UseSqlServer(connection));

            services.AddControllers();
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task12", Version = "v1" });
            });

            services.ConfigureRepositoryWrapper();

            services.AddTransient<IRepository<Operation>, OperationsRepository>();
            services.AddTransient<IRepository<OperationType>, OperationTypesRepository>();

            services.AddTransient<IOperationsService, OperationsService>();
            services.AddTransient<IService<OperationType, OperationTypeDTO>, OperationTypesService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task12 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
