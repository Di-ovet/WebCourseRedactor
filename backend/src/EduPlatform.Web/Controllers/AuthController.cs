using EduPlatform.Application.Registration;
using EduPlatform.Application.Users;
using EduPlatform.Application.Users.Registration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace EduPlatform.Web.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
        private readonly IUserRepository _users;
        private readonly IPasswordHasher _hasher;
        private readonly RegisterHandler _handler;

        public AuthController(RegisterHandler handler, IUserRepository users, IPasswordHasher hasher)
        {
            _users = users;
            _hasher = hasher;
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
        RegistrationRequest request,
        CancellationToken ct)
        {
                var result = await _handler.Execute(request, ct);
                return Ok(result);
        }

        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Token()
        {
            var request = HttpContext.GetOpenIddictServerRequest();

            if (!request.IsPasswordGrantType())
                throw new InvalidOperationException("Only password flow is supported.");

           
            var user = await _users.FindByEmailAsync(email: request.Username, CancellationToken.None);
            if (user == null || !_hasher.VerifyHashedPassword(hashedPassword: request.Password, user.PasswordHash))
            {
                return Forbid(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            var identity = new ClaimsIdentity(
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            identity.AddClaim(
                OpenIddictConstants.Claims.Subject,
                user.UserId.ToString());

            identity.AddClaim(
                OpenIddictConstants.Claims.Email,
                user.Email);

            var principal = new ClaimsPrincipal(identity);

            return SignIn(
                principal,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
    }
}