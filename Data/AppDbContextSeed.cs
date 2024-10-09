using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Entities;
using System.Text.Json;

namespace OsonAptekaFastEndpoints.Data
{
    public class AppDbContextSeed
    {
        private ILogger<AppDbContextSeed> _logger;
        public AppDbContextSeed(ILogger<AppDbContextSeed> logger)
        {
            _logger = logger;            
        }
        public async Task SeedDataAsync(AppDbContext db)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                if(!await db.Classes.AnyAsync()&&!await db.Students.AnyAsync())
                {
                    await SeedClasses(db);
                    await SeedStudents(db);
                    transaction.Commit();
                }

            }catch (Exception ex)
            {
                transaction.Rollback();
                _logger.LogError(ex, "Malumotlar qo'shilmadi.");

            }
        }
        private async Task SeedClasses(AppDbContext db)
        {
            try
            {
                var classesJson = await File.ReadAllTextAsync("Data/SeedData/class.json");
                var classes = JsonSerializer.Deserialize<List<Class>>(classesJson);
                await db.Classes.AddRangeAsync(classes);
                await db.SaveChangesAsync();
                _logger.LogInformation("Sinflar qoshildi");


            }catch (Exception ex)
            {
                _logger.LogError(ex, "Sinflar qoshishda muamo");
            }
        }
        private async Task SeedStudents(AppDbContext db)
        {
            try
            {
                var studentsJson = await File.ReadAllTextAsync("Data/SeedData/students.json");
                var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
                await db.Students.AddRangeAsync(students);
                await db.SaveChangesAsync();
                _logger.LogInformation("oquvchilar qoshildi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "oquvchilar qoshishda muamo");
            }

        }
    }
}
