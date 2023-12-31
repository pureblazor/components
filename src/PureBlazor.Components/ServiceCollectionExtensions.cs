using System.Runtime.CompilerServices;
using PureBlazor.Components.Utilities;
using Microsoft.Extensions.DependencyInjection;
using PureBlazor.Components.Styling;

[assembly: InternalsVisibleTo("Makani.Tests")]

namespace PureBlazor.Components;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMakani(this IServiceCollection services)
    {
        // javascript
        services.AddTransient<IElementUtils, ElementUtils>();
        services.AddTransient<PrismUtils>();
        services.AddTransient<TailwindBuilder>();


        // services
        services.AddSingleton<ToastService>();

        return services;
    }
}
