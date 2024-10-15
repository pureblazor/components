using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Primitives;
using Theme = Pure.Blazor.Components.Primitives.Theme;

namespace Pure.Blazor.Components;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddPureBlazorComponents(this WebAssemblyHostBuilder builder,
        PureTheme? theme = null)
    {
        // javascript
        builder.Services.AddSingleton<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddScoped<AlertService>();
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddCascadingValue(_ =>
        {
            theme ??= new DefaultTheme();
            var source = new CascadingValueSource<PureTheme>(theme, isFixed: true);
            return source;
        });

        builder.Services.TryAddCascadingValue(_ => Theme.Auto);
        return builder;
    }
}
