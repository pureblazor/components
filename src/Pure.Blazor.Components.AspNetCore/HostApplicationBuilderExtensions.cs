using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pure.Blazor.Components.Buttons;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.AspNetCore;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddPureBlazorComponents(this IHostApplicationBuilder builder,
        IPureTheme? theme = null)
    {
        // javascript
        builder.Services.AddScoped<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddScoped<AlertService>();
        builder.Services.AddScoped<DialogService>();

        builder.Services.AddCascadingValue(sp =>
        {
            theme ??= new DefaultTheme();
            var source = new CascadingValueSource<IPureTheme>(theme, isFixed: true);
            return source;
        });

        return builder;
    }
}
