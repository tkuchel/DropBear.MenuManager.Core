using Microsoft.Extensions.DependencyInjection;

namespace DropBear.MenuManager.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMenuManager(this IServiceCollection services, Action<MenuManagerOptions> configure)
    {
        services.Configure(configure);
        services.AddSingleton<MenuManager>();
        return services;
    }
}
