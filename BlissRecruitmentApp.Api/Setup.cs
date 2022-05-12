using Microsoft.Extensions.DependencyInjection;
using BlissRecruitmentApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace BlissRecruitmentApp.Api
{
    public static class Setup
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DataContext>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {

        }

        public static void ConfigureServices(this IServiceCollection services)
        {

        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {

        }

        public static void ConfigureMigrations(this IApplicationBuilder app, DataContext context)
        {
            context.Database.Migrate();
        }
    }
}
