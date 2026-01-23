using EduPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.Infrastructure.Persistence;

public sealed class EduPlatformDbContext(DbContextOptions<EduPlatformDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Courses.Course> Courses => Set<Domain.Courses.Course>();
    public DbSet<Domain.Users.User> Users => Set<Domain.Users.User>();
}
