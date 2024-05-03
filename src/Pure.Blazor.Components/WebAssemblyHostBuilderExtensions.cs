using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pure.Blazor.Components.Buttons;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddPureBlazorComponents(this WebAssemblyHostBuilder builder,
        IPureTheme? theme = null)
    {
        // javascript
        builder.Services.AddSingleton<IElementUtils, ElementUtils>();

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
