using Microsoft.EntityFrameworkCore;

namespace OsonAptekaFastEndpoints.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
            
        }
    }
}
