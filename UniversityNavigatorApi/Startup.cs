using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniversityNavigation.Infrastructure.Repository.Interface;
using UniversityNavigator.BLL.Repository;
using UniversityNavigator.DomainModel.GeneratedDataModel;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
