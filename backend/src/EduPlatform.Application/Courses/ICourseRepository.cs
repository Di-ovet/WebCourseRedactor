using EduPlatform.Domain.Courses;

namespace EduPlatform.Application.Courses;

public interface ICourseRepository
{
	Task AddAsync(Course course, CancellationToken ct);
}
