using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WorkoutBackend.Identity;

public static class IdentityServices
{
    public static IServiceCollection AddIdentityContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<WorkItOutDbContext>(options => options.UseSqlServer(connectionString));

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.User.RequireUniqueEmail = true;
        });

        services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies(o => { });

        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "WorkItOut";
            options.ExpireTimeSpan = TimeSpan.FromDays(30);
        });

        services.AddIdentityCore<IdentityUser>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
        })
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<WorkItOutDbContext>()
        .AddSignInManager();

        return services;
    }
}
