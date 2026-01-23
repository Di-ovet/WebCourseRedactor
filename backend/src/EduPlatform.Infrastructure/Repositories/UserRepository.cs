using EduPlatform.Domain.Users;
using EduPlatform.Application.Users;
using EduPlatform.Infrastructure.Persistence;

namespace EduPlatform.Infrastructure.Repositories
{
    internal class UserRepository(EduPlatformDbContext db) : IUserRepository
    {
        private readonly EduPlatformDbContext _db = db;
        public async Task AddAsync(User user, CancellationToken ct)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);
        }
    }
}
