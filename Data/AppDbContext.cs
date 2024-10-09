using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Entities;

namespace OsonAptekaFastEndpoints.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(p => p.Class)
                .WithMany()
                .HasForeignKey(p => p.ClassId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
