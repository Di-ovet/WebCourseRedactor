using EduPlatform.Domain.Users;

namespace EduPlatform.Application.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user, CancellationToken ct);
    }
}
