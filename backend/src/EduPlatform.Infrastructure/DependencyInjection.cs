using Microsoft.Extensions.DependencyInjection;
using EduPlatform.Application.Common.Security;
using EduPlatform.Infrastructure.Security;

namespace EduPlatform.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
