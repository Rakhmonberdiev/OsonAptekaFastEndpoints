using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.Data.Repository;
using OsonAptekaFastEndpoints.Data.Repository.Base;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IBaseRepo, BaseRepo>();
            return services;
        }
    }
}
