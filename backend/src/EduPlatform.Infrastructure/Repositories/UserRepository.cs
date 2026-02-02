using System;
using System.Threading;
using System.Threading.Tasks;
using EduPlatform.Application.Users;
using EduPlatform.Domain.Users;
using EduPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly EduPlatformDbContext _db;

        public UserRepository(EduPlatformDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task AddAsync(User user, CancellationToken ct)
        {
            ArgumentNullException.ThrowIfNull(user);

            await _db.Users.AddAsync(user, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<User?> FindByEmailAsync(string email, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            return await _db.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email, ct);
        }
    }
}
