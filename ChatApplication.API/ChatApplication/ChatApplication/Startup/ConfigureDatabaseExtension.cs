using ChatApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApplication.Startup
{
    public static class ConfigureDatabaseExtension
    {
        public static void ConfigureDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(opt => { opt.UseNpgsql(configuration.GetConnectionString("db")); });
        }
    }
}