using Framework.Tools.Contract;
using Framework.Tools.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Tools;

public static class ServiceExtensions
{
    public static void AddSingletonMediator(this IServiceCollection services)
    {
        services.AddSingleton<IMediator, Mediator>();
    }

    public static void AddScopedMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
    }
}