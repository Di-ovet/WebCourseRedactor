using EduPlatform.Domain.Courses;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.Infrastructure.Persistence;

public sealed class EduPlatformDbContext(DbContextOptions<EduPlatformDbContext> options) : DbContext(options)
{
    public DbSet<Course> Courses => Set<Course>();
}
