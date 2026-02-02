using EduPlatform.Application.Registration;
using EduPlatform.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Users.Registration
{
    public sealed class RegisterHandler
    {
        private readonly IUserRepository _users;
        private readonly IPasswordHasher _hasher;

        public RegisterHandler(IUserRepository users, IPasswordHasher hasher)
        {
            _users = users;
            _hasher = hasher;
        }

        public async Task<RegistrationResponse> Execute( 
            RegistrationRequest request,
            CancellationToken ct)
        {
            var hash = _hasher.HashPassword(request.password);
            var user = User.Create(request.lastName, request.firstName, request.middleName, request.email, hash, DateTime.UtcNow
                );

            await _users.AddAsync(user, CancellationToken.None);
            return new RegistrationResponse {
                UserId = user.UserId
            };
        }
    }
}
