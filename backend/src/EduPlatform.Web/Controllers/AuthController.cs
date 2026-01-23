using EduPlatform.Application.Users.Registration;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace EduPlatform.Web.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
        //TODO: registration with handler and req/res

        private readonly RegistrationHandler _handler = handler;

        [HttpPost]
        public async Task<IActionResult> Create(
            RegistartionRequest request,
            CancellationToken ct)
        {
            var result = await _handler.Execute(request, ct);
            return Ok(result);
        }
    }
}