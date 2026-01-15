using EduPlatform.Application.Courses;
using EduPlatform.Domain.Courses;
using EduPlatform.Infrastructure.Persistence;

namespace EduPlatform.Infrastructure.Repositories;

public sealed class CourseRepository(EduPlatformDbContext db) : ICourseRepository
{
	private readonly EduPlatformDbContext _db = db;

    public async Task AddAsync(Course course, CancellationToken ct)
	{
		_db.Courses.Add(course);
		await _db.SaveChangesAsync(ct);
	}
}
