using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityNavigation.Infrastructure.Repository.Interface;
using UniversityNavigator.BLL.Repository;
using UniversityNavigator.DomainModel.GeneratedDataModel;
using Microsoft.OpenApi.Models;

namespace UniversityNavigatorApi
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
            services.AddDbContext<UniversityNavigatorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UniversityNavigatorConnection")));
            services.AddTransient<IRepositoryUniversal<Audience>, AudienceRepository>();
            services.AddTransient<IRepositoryUniversal<AudienceImage>, AudienceImageRepository>();
            services.AddTransient<IRepositoryUniversal<AudienceQuickSearch>, AudienceQuickSearchRepository>();
            services.AddControllers();

            //swagger
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "UniversityNavigatorApi",
                Version = "v1",
                Description = "Api that provides all information related to University location/navigation",
                Contact = new OpenApiContact
                {
                    Name = "Viktor Siryk",
                    Email = "senseyvik22@gmail.com"
                }
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(context => context.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityNavigatorApi"));

            #endregion

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
