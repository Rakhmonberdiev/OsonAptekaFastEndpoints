using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;

namespace OsonAptekaFastEndpoints.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppService(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DbConnection"));
            });
            return services;
        }
    }
}
