![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pureblazor/components/build.yml)
![GitHub last commit](https://img.shields.io/github/last-commit/pureblazor/components)
![NuGet Version](https://img.shields.io/nuget/vpre/PureBlazor.Components)
[![Discord](https://img.shields.io/discord/984241021225414787)](https://discord.gg/PeBbYy6WKq)
[![PureBlazor](https://img.shields.io/badge/pureblazor-rgb(7%2C%2072%2C%20115))](https://pureblazor.com)

# PureBlazor Components

> [!NOTE]
> This component library is pre-release software.


Native Blazor UI components. Free to use for any Blazor project.

Works seamlessly with [PureBlazor CMS](https://pureblazor.com).

# Features

- **Native Blazor** - We want components built for Blazor, not a wrapper around a JavaScript library.
- **Blazing Fast** - We want components that are fast on every platform.
- **Headless Mode** - We want components that are easy to customize.
- **Tailwind Compatible** - Automatically merge your Tailwind classes with built-in styles.

[Explore Components](https://pureblazor.com/components)

[Benchmarks](/tests/Benchmarks/BenchmarkDotNet.Artifacts/results)

> [!NOTE]
> This documentation is incomplete. Not all components are documented yet.
>
> Please feel free to ask questions in the [Discord](https://discord.gg/PeBbYy6WKq), open an issue, or create a pull
> request.

# Getting started

## Installation

Install the `PureBlazor.Components` NuGet package.

```sh
dotnet add package PureBlazor.Components
```

Register the components and services to your `Program.cs` file.

```csharp
builder.Services.AddPureBlazorComponents();
```

## Theming

PureBlazor components use Tailwind CSS and are designed to be customizable with pure CSS or with more Tailwind styles.

Additionally, there are more extensibility points for customizing the components with C#. Documentation will come as
this is further solidified.

## Headless Mode

You can wrap individual components, or your entire app using a CascadingValue for the `Theme` property.

```razor
<CascadingValue Value="Theme.Off">
    <PureButton>Unstyled button</PureButton>
</CascadingValue>
```

### Use the default styles

Include `pureblazor.css` in your `App.Razor` file, in the `<head>` tag.

```razor
<script src="_content/PureBlazor.Components/pureblazor.css"></script>
```

### Use [dotnet-tailwind]() or the Tailwind CLI

PureBlazor components are compatible with Tailwind CSS. You can use the `dotnet-tailwind` tool to compile your Tailwind,
or use the Tailwind CLI.

### Use the Tailwind CDN

Include the following scripts in your `App.razor` file. Change your `brand` colors to match your desired primary color.

```razor
<script src="https://cdn.tailwindcss.com"></script>
<script>
    tailwind.config = {
        darkMode: 'class',
        theme: {
            extend: {
                fontFamily: {
                    sans: ['Inter var', 'ui-sans-serif', 'system-ui', '-apple-system', 'BlinkMacSystemFont', "Segoe UI", 'Roboto', "Helvetica Neue", 'Arial', "Noto Sans", 'sans-serif', "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"],
                },
                borderRadius: {
                    'xs': '0.0625rem',
                },
                colors: {
                    brand: {
                        '50': '#eff9ff',
                        '100': '#dff1ff',
                        '200': '#b7e5ff',
                        '300': '#77d1ff',
                        '400': '#2fbbff',
                        '500': '#04a3f3',
                        '600': '#0081d0',
                        '700': '#0067a8',
                        '800': '#015486',
                        '900': '#074873',
                        '950': '#052e4c',
                    },
                }
            }
        },
    }
</script>
```

# FAQ

### Why not use `xx` library?

Our features section is a good place to start to understand our goals.

In addition, our components are built to work seamlessly with the PureBlazor CMS.

### Is this library free to use?

- Yes! This library is free to use for any Blazor project.

### Can I use this library with .NET MAUI Blazor projects?

- This library should work with .NET MAUI, but we have not tested it yet. Please let us know if you have any issues.

### Can I use this library with Blazor WebAssembly / Blazor Server / InteractiveAuto?

- Yes. This library supports all Blazor hosting models.

### Is this library production-ready?

- No. This library is still in development.

### Do you accept contributions?

- Yes! We accept contributions. Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for more information.

### How do I report a bug?

- Please open an issue on the [GitHub repository](https://github.com/pureblazor/components/issues/new/choose).
- Please include as much information as possible, including the version of the library you are using, the browser you
  are using, and any steps to reproduce the issue.
