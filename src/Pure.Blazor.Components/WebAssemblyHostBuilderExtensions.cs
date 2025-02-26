using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using TailwindMerge.Extensions;

namespace Pure.Blazor.Components;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPureBlazor(this IServiceCollection services,
        PureTheme? theme = null)
    {
        // javascript
        services.AddScoped<IElementUtils, ElementUtils>();

        // services
        services.AddScoped<AlertService>();
        services.AddScoped<DialogService>();

        services.AddTailwindMerge();

        // theme
        services.AddCascadingValue(_ =>
        {
            theme ??= new DefaultTheme();
            var source = new CascadingValueSource<PureTheme>(theme, isFixed: false);
            return source;
        });

        services.TryAddCascadingValue(_ => Theme.Auto);
        return services;
    }
}
