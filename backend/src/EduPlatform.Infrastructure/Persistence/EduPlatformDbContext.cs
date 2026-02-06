using System;
using EduPlatform.Domain.Courses;
using EduPlatform.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EduPlatform.Infrastructure.Persistence
{
    public class EduPlatformDbContext : DbContext
    {
        public EduPlatformDbContext(DbContextOptions<EduPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }

    // Фабрика для создания DbContext в режиме design-time (migrations, ef tools).
    public class EduPlatformDbContextFactory : IDesignTimeDbContextFactory<EduPlatformDbContext>
    {
        public EduPlatformDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EduPlatformDbContext>();

            // Попробуйте задать CONNECTION_STRING в переменных окружения на CI/локальной машине,
            // иначе используем безопасный локальный fallback (замените на ваши параметры).
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                ?? "Host=localhost;Database=eduplatform;Username=eduuser;Password=edupassword";

            builder.UseNpgsql(connectionString, o =>
                o.MigrationsAssembly(typeof(EduPlatformDbContext).Assembly.FullName));

            return new EduPlatformDbContext(builder.Options);
        }
    }
}