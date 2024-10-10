using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.Data.Repository;

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
            services.AddScoped<IStudentRepo, StudentRepo>();
            return services;
        }
    }
}
