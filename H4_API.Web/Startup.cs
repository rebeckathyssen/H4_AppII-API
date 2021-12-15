using H4_API.Application;
using H4_API.Application.Interfaces;
using H4_API.Core;
using H4_API.Domain.Interfaces;
using H4_API.Infrastructure;
using H4_API.Infrastructure.Interfaces;
using H4_API.Infrastructure.Repository;
using H4_API.Infrastructure.UnitOfWork;
using H4_API.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace H4_API.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InjectDbServices(services);
            InjectApplication(services);
            InjectInfrastructure(services);
            InjectUseCase(services);
            SwaggerServiceConfig(services);

            services.AddCors();
            services.AddControllers();
            services.AddSpaStaticFiles(conf => { conf.RootPath = "wwwroot"; });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }
            SwaggerAppConfig(app);

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa => { spa.Options.SourcePath = "/"; });
        }

        #region Swagger
        private static void SwaggerServiceConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }
        private static void SwaggerAppConfig(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.InjectStylesheet("/swagger-ui/swaggerdark.css");
            });
        }
        #endregion

        #region InjectServices
        private void InjectDbServices(IServiceCollection services)
        {
            services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultDb")));
            services.AddScoped<IDatabaseContext, ExampleDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        private void InjectUseCase(IServiceCollection services)
        {
            services.AddScoped<UserUseCase>();
        }

        private void InjectInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private void InjectApplication(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
        #endregion
    }
}
