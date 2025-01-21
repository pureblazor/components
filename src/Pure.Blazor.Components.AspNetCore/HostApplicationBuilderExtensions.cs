using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pure.Blazor.Components.AspNetCore;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddPureBlazorComponents(this IHostApplicationBuilder builder,
        PureTheme? theme = null)
    {
        // javascript
        builder.Services.AddScoped<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddScoped<AlertService>();
        builder.Services.AddScoped<DialogService>();

        builder.Services.AddCascadingValue(sp =>
        {
            theme ??= new DefaultTheme();
            var source = new CascadingValueSource<PureTheme>(theme, isFixed: true);
            return source;
        });

        builder.Services.TryAddCascadingValue(_ => Theme.Auto);

        return builder;
    }
}
