using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlissRecruitmentApp.Data.Context;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlissRecruitmentApp.Api
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
            services.AddEntityFrameworkSqlServer().AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"), m =>
                {
                    m.MigrationsAssembly("BlissRecruitmentApp.Api");
                    m.MigrationsHistoryTable("__MyMigrationsHistory", "Bliss");
                }));

            services.ConfigureDbContext();

            services.ConfigureRepositories();

            services.ConfigureServices();

            services.ConfigureSwagger();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.ConfigureMigrations(context);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
