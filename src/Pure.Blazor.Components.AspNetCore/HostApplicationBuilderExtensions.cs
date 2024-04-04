using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;

namespace Pure.Blazor.Components.AspNetCore;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddPureBlazorComponents(this IHostApplicationBuilder builder)
    {
        // javascript
        builder.Services.AddScoped<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddScoped<ToastService>();
        builder.Services.AddScoped<DialogService>();

        return builder;
    }
}
