namespace EduPlatform.Domain.Courses;

public class Course
{
    protected Course() { }
    public Guid Id { get; private set; }
    public Guid TeacherId { get; private set; }
    public string Title { get; private set; }
    public CourseStatus Status { get; private set; }

    public Course(Guid teacherId, string title)
    {
        if (teacherId == Guid.Empty)
            throw new ArgumentException("Нужен учитель", nameof(teacherId));
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Нужно название", nameof(title));
        Id = Guid.NewGuid();
        TeacherId = teacherId;
        Title = title;
        Status = CourseStatus.Draft;
    }
    public void Publish()
    {
        if (Status != CourseStatus.Draft)
            throw new InvalidOperationException("Только черновик может быть опубликован");
        Status = CourseStatus.Active;
    }
    public void Finish()
    {
        if (Status != CourseStatus.Active)
            throw new InvalidOperationException("Только активный курс может быть завершен");    
        Status = CourseStatus.Finished;

    }
}
