![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pureblazor/components/build.yml)
![GitHub last commit](https://img.shields.io/github/last-commit/pureblazor/components)
![NuGet Version](https://img.shields.io/nuget/vpre/PureBlazor.Components)
[![Discord](https://img.shields.io/discord/984241021225414787)](https://discord.gg/PeBbYy6WKq)
[![PureBlazor](https://img.shields.io/badge/pureblazor-rgb(7%2C%2072%2C%20115))](https://pureblazor.com)

# PureBlazor Components

> [!NOTE]
> This component library is pre-release software.


These components are native Blazor UI components that are free to use for any Blazor project. The components also work seamlessly with [PureBlazor CMS](https://pureblazor.com).

# Features

- **Native Blazor** - The components are built for Blazor. They are not a wrapper around a JavaScript library.
- **Blazing Fast** - The components are fast on every platform.
- **Headless Mode** - The components have a fully customizable UI. You may disable all styles with a single property.
- **Tailwind Compatible** - The components have  built-in styles that automatically merge with your Tailwind classes.

[Explore Components](https://pureblazor.com/components)

[Benchmarks](/tests/Benchmarks/README.md)

> [!NOTE]
> This documentation is incomplete. We have not documented all components yet.
>
> Please, feel free to ask questions in our [Discord server](https://discord.gg/PeBbYy6WKq), open an issue, or create a pull
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

We have designed PureBlazor's components to be compatible with Tailwind CSS so you can customize with Tailwind or any custom CSS.

In the future, we will offer additional extensibility points to customize the components with C#. We will publish documentation on this as we solidify it further.

### Use the default styles

Include `pureblazor.css` in your `App.Razor` file, in the `<head>` tag.

```razor
<link rel="stylesheet" href="_content/PureBlazor.Components/pureblazor.css" />
```

To customize further on top of these default styles with Tailwind CSS, see [tailwind.md](/tailwind.md).

### Ad-hoc customization

All components have a `Styles` parameter that accepts a `string` of CSS classes. If you use Tailwind, the classes
will merge with the default styles. The `Styles` parameter is parsed and evaluated for conflicts; conflicting styles
passed in here will supersede default classes.

For example, to change the shade of red for the `Danger` accent, which is `bg-red-900` by default:

```razor
<PureButton Accent="Accent.Danger" Styles="bg-red-600">Default button</PureButton>
```

### C# customization

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

Headless mode turns the UI components into completely unstyled, fully customizable, and accessible components.

You can enable headless mode by setting the `Theme` property to `Off` using a `CascadingValue`. You may do so for individual
components or wrap your entire application in a `CascadingValue`.

```razor
<CascadingValue Value="Theme.Off">
    <PureButton>Unstyled button</PureButton>
</CascadingValue>
```

# FAQ

### Why not use another `xx` library?

- We have built these components to work seamlessly with the PureBlazor CMS. In addition, please, review our Features section to understand our broader goals.

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
