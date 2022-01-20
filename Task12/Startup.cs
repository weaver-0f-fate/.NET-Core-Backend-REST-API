using Core.Models;
using Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Task12.Extensions;
using Task12.FluentValidator;

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
            services.AddFluentValidation();
            services.AddTransient<IValidator<Core.Models.OperationType>, OperationTypeValidator>();
            services.AddTransient<IValidator<Operation>, OperationValidator>();

            services.AddDbContext<RepositoryContext>(options => 
                options.UseSqlServer(connection, x => x.MigrationsAssembly("Data")));

            services.AddControllers();
            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task12", Version = "v1" });
            });

            services.ConfigureRepositories();
            services.ConfigureServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RepositoryContext context) {
            context.Database.Migrate();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task12 v1"));
            }

            app.UseStatusCodePages();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
