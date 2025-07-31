using Microsoft.Extensions.DependencyInjection;
using TailwindMerge.Extensions;

namespace PureBlazor;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPureBlazor(this IServiceCollection services)
    {
        services.AddTailwindMerge();
        return services;
    }
}
