using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.AspNetCore;
using PureBlazor.com;
using PureBlazor.com.Client;
using PureBlazor.com.Components;
using PureBlazor.Pages;
using PureBlazor.Pages.AspNetCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using ZiggyCreatures.Caching.Fusion;
using _Imports = PureBlazor.com.Client._Imports;

var seq = Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .Enrich.WithProperty("app", "pureblazor.com")
    .WriteTo.Seq(seq)
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host
        .UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .MinimumLevel.Verbose()
            .Enrich.FromLogContext()
            .Enrich.WithProperty("app", "pureblazor.com")
            .WriteTo.Seq(seq)
            .WriteTo.Console(new JsonFormatter()));

    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents()
        .AddInteractiveWebAssemblyComponents();

    builder.Services.AddSingleton<SnippetService>();
    builder.Services.AddTransient<NewsletterService>();
    builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("Email"));
    builder.Services.AddApplicationInsightsTelemetry(o =>
    {
        o.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
    });
    builder.Services.AddHttpClient<ServerClient>(options => { options.BaseAddress = new Uri("https://localhost"); });
    builder.Services.AddTransient<HtmlRenderer>();


    // Add PureBlazor UI components
    builder.AddPureBlazorComponents();

    // Add PureBlazor CMS components
    builder.Services.AddPureBlazor(new()
    {
        Authentication = new(
            builder.Configuration["PureBlazor:Authentication:Authority"]!,
            builder.Configuration["PureBlazor:Authentication:ClientId"]!,
            builder.Configuration["PureBlazor:Authentication:ClientSecret"]!),
        Api = builder.Configuration["PureBlazor:Host"]!,
        Site = builder.Configuration["PureBlazor:Site"]!,
    }).WithPages();

    builder.Services.AddFusionCache()
        .WithDefaultEntryOptions(new FusionCacheEntryOptions { Duration = TimeSpan.FromMinutes(2) });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseAntiforgery();
    app.UseStaticFiles();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode()
        .AddAdditionalAssemblies(typeof(_Imports).Assembly);

    app.UsePureBlazor().WithPages();

    app.MapPost("/newsletter/sign-up",
        async (NewsletterService service, NewsletterForm form) => { await service.SendEmail(form); });

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Host terminated unexpectedly: {Message}", e.Message);
}

public class EmailOptions
{
    public string ApiKey { get; set; }
}

