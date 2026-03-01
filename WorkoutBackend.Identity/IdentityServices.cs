using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkoutBackend.Identity;

public static class IdentityServices
{
    public static IServiceCollection AddIdentityContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WorkItOutDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
