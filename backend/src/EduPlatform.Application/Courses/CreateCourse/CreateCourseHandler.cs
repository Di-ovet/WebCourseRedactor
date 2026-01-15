using EduPlatform.Domain.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Courses.CreateCourse
{
    public sealed class CreateCourseHandler(ICourseRepository repository)
    {
        private readonly ICourseRepository _repository = repository;

        public async Task<CreateCourseResponse> Execute(
            CreateCourseRequest request,
            CancellationToken ct)
        {
            var course = new Course(
                request.TeacherId,
                request.Title
            );

            await _repository.AddAsync(course, ct);

            return new CreateCourseResponse
            {
                CourseId = course.Id
            };
        }
    }
}
