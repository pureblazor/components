![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pureblazor/components/build.yml)
![GitHub last commit](https://img.shields.io/github/last-commit/pureblazor/components)
[![Discord](https://img.shields.io/discord/984241021225414787)](https://discord.gg/PeBbYy6WKq)
[![PureBlazor](https://img.shields.io/badge/pureblazor-rgb(7%2C%2072%2C%20115))](https://pureblazor.com)

# PureBlazor Components

PureBlazor Components built for the [PureBlazor CMS](https://pureblazor.com)

# Getting started

Blazor UI components for the PureBlazor CMS. Free to use for any Blazor project.

## Installation

`dotnet add package PureBlazor.Components`

> [!NOTE]
> The Nuget package currently only supports use with
> the [Tailwind CDN](https://tailwindcss.com/docs/installation/play-cdn).
>
> If you wish to build the styles at compile time, you must clone this repository and include it in your project.

## Screenshots
![](docs/alerts.gif)
![](docs/buttons.png)
![](docs/indicators.png)
![](docs/paging.png)

## Demo

> [!WARNING]  
> Demo has rough edges. Handle with caution.

https://components.wasmhost.dev

# Goals

- [x] Performance (see `/tests/benchmarks`)
- [x] Simplicity

# FAQ

### Why not use `xx` library?

- There are many great libraries out there, but we wanted to build something that was simple and easy to use. We also
  wanted to build something that was tailored to the PureBlazor CMS.
- We also wanted to build something that was fast. We have a benchmark suite in `/tests/benchmarks` that we use to
  measure performance.
- Ultimately, we think there is plenty of room for more libraries in the Blazor ecosystem.

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

