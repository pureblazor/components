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
- **Headless Mode** - Fully customizable UI components. Disable all styles with a single property.
- **Tailwind Compatible** - Automatically merge your Tailwind classes with built-in styles.

[Explore Components](https://pureblazor.com/components)

[Benchmarks](/tests/Benchmarks/README.md)

> [!NOTE]
> This documentation is incomplete. Not all components are documented yet.
>
> Please feel free to ask questions in the [Discord](https://discord.gg/PeBbYy6WKq), open an issue, or create a pull
> request.

# Getting started

## Installation

### InteractiveWebAssembly / SSR

Install the `PureBlazor.Components` NuGet package to your Client project.

```sh
dotnet add package PureBlazor.Components
```

Register the components and services to your `Program.cs` file.

```csharp
builder.AddPureBlazorComponents();
```

### InteractiveServer / InteractiveAuto

You'll need to add the ASP.NET Core integration package to your Server project and update your `Program.cs` file, in
addition to the Client Project.

```sh
dotnet add package PureBlazor.Components.AspNetCore
```

## Theming

PureBlazor components use Tailwind CSS and are designed to be customizable with Tailwind or any custom CSS.

Additionally, there are more extensibility points for customizing the components with C#. Documentation will come as
this is further solidified.

### Use the default styles

Include `pureblazor.css` in your `App.Razor` file, in the `<head>` tag.

```razor
<link rel="stylesheet" href="_content/PureBlazor.Components/pureblazor.css" />
```

To customize further on top of these default styles with TailwindCSS, see [tailwind.md](/tailwind.md).

### Ad-hoc customization

All components have a `Styles` parameter that accepts a `string` of CSS classes. If you are using Tailwind, the classes
will be merged with the default styles. The `Styles` parameter is parsed and evaluated for conflicts; conflicting styles
passed in here will supersede default classes.

For example, to change the shade of red for the `Danger` accent, which is `bg-red-900` by default:

```razor
<PureButton Accent="Accent.Danger" Styles="bg-red-600">Default button</PureButton>
```

### Customizing with C#

You can override the default theme in C# by creating a `PureStyles` object and passing it to a `CascadingValue`.
The `PureStyles` object has properties for each component style.

```razor
<CascadingValue Value="styles">
    <PureButton Accent="Accent.Danger">Default button</PureButton>
</CascadingValue>

@code {
    PureStyles styles = new();
}
```

> [!IMPORTANT]
> Not all components have C# customization available yet.

## Headless Mode

Headless mode turns the UI components into completely unstyled, accessible components. Fully customizable.

Enable headless mode by setting the `Theme` property to `Off` using a `CascadingValue`. You can do this for individual
components or wrap your entire application in a `CascadingValue`.

```razor
<CascadingValue Value="Theme.Off">
    <PureButton>Unstyled button</PureButton>
</CascadingValue>
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
