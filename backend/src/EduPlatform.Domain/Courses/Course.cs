namespace EduPlatform.Domain.Courses;

public class Course
{
    public Guid Id { get; private set; }
    public Guid CreatorId { get; private set; }
    public string Title { get; private set; }
    public CourseStatus Status { get; private set; }

    protected Course() { }

    public Course(Guid teacherId, string title)
    {
        Id = Guid.NewGuid();
        CreatorId = teacherId;
        Title = title;
        Status = CourseStatus.Draft;
    }
}
