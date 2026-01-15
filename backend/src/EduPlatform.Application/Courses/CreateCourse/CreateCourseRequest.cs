using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Courses.CreateCourse
{
    public class CreateCourseRequest
    {
        public Guid TeacherId { get; init; }
        public string Title { get; init; } = null!;
    }
}
