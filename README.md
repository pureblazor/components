![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pureblazor/components/build.yml)
![GitHub last commit](https://img.shields.io/github/last-commit/pureblazor/components)
![NuGet Version](https://img.shields.io/nuget/vpre/PureBlazor.Components)
[![Discord](https://img.shields.io/discord/984241021225414787)](https://discord.gg/PeBbYy6WKq)
[![PureBlazor](https://img.shields.io/badge/pureblazor-rgb(7%2C%2072%2C%20115))](https://pureblazor.com)

# PureBlazor Components

> [!NOTE]
> This component library is pre-release software.


These components are native Blazor UI components that are free to use for any Blazor project.

# Getting started

## Installation

Install the `PureBlazor.Components` NuGet package to your Client project.

```sh
dotnet add package PureBlazor.Components
```

Add to your `GlobalUsings.cs` file in the Client project:

```csharp
global using static PureBlazor.Components.Variants;
global using static PureBlazor.Components.Sizes;
global using PureBlazor.Components;
```

## Example usage

```razor
<Button Variant="Secondary" Size="Sm" @onclick="EnterEditMode">Edit Observer</Button>
<Button Variant="Primary" Size="Sm" @onclick="CheckHealthNowAsync">Check now</Button>
```

## Theming
Docs TODO

# FAQ

### Why not use another `xx` library?

- This library is built to be lightweight and follow a style convention similar to ShadCN.
- For more complex components, we recommend using other libraries like [Blazorise](https://blazorise.com/) or [MudBlazor](https://mudblazor.com/).

### Is this library free to use?

- Yes! This library is free to use for any Blazor project.

### Can I use this library with .NET MAUI Blazor projects?

- This library should work with .NET MAUI, but we have not tested it yet. Please, let us know if you encounter any issues.

### Can I use this library with Blazor WebAssembly / Blazor Server / InteractiveAuto?

- Yes! This library supports all Blazor hosting models.

### Is this library production-ready?

- No. This library is pre-release software still in development.

### Do you accept contributions?

- Yes! We accept contributions. Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for more information.

### How do I report a bug?

- Please, open an issue on the [GitHub repository](https://github.com/pureblazor/components/issues/new/choose).
- Please, include as much information as possible, including what library version and browser you
  are using, and any steps to reproduce the issue.
