using Microsoft.AspNetCore.Identity;
using EduPlatform.Application.Users;

namespace EduPlatform.Infrastructure.Security
{
    internal sealed class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _passwordHasher = new();

        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }

        public bool VerifyHashedPassword(object user, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(
            user,
            providedPassword,
            hashedPassword
            );

            return result == PasswordVerificationResult.Success;
        }
    }
}
