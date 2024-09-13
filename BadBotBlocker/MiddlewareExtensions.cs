using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BadBotBlocker;

public static class BadBotMiddlewareExtensions
{
    public static IApplicationBuilder UseBadBotBlocker(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<BadBotMiddleware>();
    }

    public static IServiceCollection AddBadBotBlocker(this IServiceCollection services, Action<BadBotOptions>? configureOptions = null)
    {
        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        else
        {
            services.AddSingleton<BadBotOptions>();
        }

        return services;
    }
}
