using EduPlatform.Application.Users;
using EduPlatform.Application.Users.Registration;
using EduPlatform.Infrastructure.Repositories;
using EduPlatform.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace EduPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddScoped<RegisterHandler>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
