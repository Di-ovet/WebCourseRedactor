using EduPlatform.Application.Courses.CreateCourse;
using Microsoft.AspNetCore.Mvc;

namespace EduPlatform.Web.Controllers;

[ApiController]
[Route("api/courses")]
public sealed class CoursesController(CreateCourseHandler handler) : ControllerBase
{
    private readonly CreateCourseHandler _handler = handler;

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateCourseRequest request,
        CancellationToken ct)
    {
        var result = await _handler.Execute(request, ct);
        return Ok(result);
    }
}
