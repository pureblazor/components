using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;

[assembly: InternalsVisibleTo("Makani.Tests")]

namespace Pure.Blazor.Components;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPureBlazorComponents(this IServiceCollection services)
    {
        // javascript
        services.AddTransient<IElementUtils, ElementUtils>();
        services.AddTransient<PrismUtils>();


        // services
        services.AddSingleton<ToastService>();
        services.AddScoped<DialogService>();

        return services;
    }
}
