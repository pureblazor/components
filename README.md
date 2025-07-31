![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/pureblazor/components/build.yml)
![GitHub last commit](https://img.shields.io/github/last-commit/pureblazor/components)
![NuGet Version](https://img.shields.io/nuget/vpre/PureBlazor.Components)
[![Discord](https://img.shields.io/discord/984241021225414787)](https://discord.gg/PeBbYy6WKq)
[![PureBlazor](https://img.shields.io/badge/pureblazor-rgb(7%2C%2072%2C%20115))](https://pureblazor.com)

# PureBlazor Components

> [!NOTE]
> This component library is pre-release software.


These components are native Blazor UI components that are free to use for any Blazor project.

## Available components
- Button
- Sheet
- Input
- Skip to content

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

Setup Tailwind in your Blazor project folder by adding a `styles.css` and `package.json` file that looks something like this:

```json
{
    "scripts": {
        "build": "npx @tailwindcss/cli -i styles.css -o ./wwwroot/app.css",
        "watch": "npx @tailwindcss/cli -i styles.css -o ./wwwroot/app.css --watch"
    },
    "dependencies": {
        "@tailwindcss/cli": "^4.1.11",
        "tailwindcss": "^4.1.11"
    }
}

```

## Example usage

```razor
<Button Variant="Secondary" Size="Sm" @onclick="EnterEditMode">Edit Observer</Button>
<Button Variant="Primary" Size="Sm" @onclick="CheckHealthNowAsync">Check now</Button>
```

## Theming
This library depends on Tailwind. Use CSS variables to easily customize the theme of the components.

If you are familiar with [ShadCN](https://github.com/shadcn-ui/ui), you will find the theming approach similar, as it is heavily inspired by it, if not outright copied.

1. Set up Tailwind in your Blazor project.
2. Add the below CSS variables to your tailwind input CSS file (e.g., `site.css` or `app.css`).
3. Adjust the CSS variables to match your design requirements.

```css
@import "tailwindcss";
@custom-variant dark (&:where(.dark, .dark *));

:root {
    --background: hsl(0 0% 100%);
    --foreground: hsl(240 10% 3.9%);
    --card: hsl(0 0% 100%);
    --card-foreground: hsl(240 10% 3.9%);
    --popover: hsl(0 0% 100%);
    --popover-foreground: hsl(240 10% 3.9%);
    --primary: hsl(240 5.9% 10%);
    --primary-foreground: hsl(0 0% 98%);
    --secondary: hsl(240 4.8% 95.9%);
    --secondary-foreground: hsl(240 5.9% 10%);
    --muted: hsl(240 4.8% 95.9%);
    --muted-foreground: hsl(240 3.8% 46.1%);
    --accent: hsl(240 4.8% 95.9%);
    --accent-foreground: hsl(240 5.9% 10%);
    --destructive: hsl(2.6 86.9% 41.8%);
    --destructive-foreground: hsl(0 0% 98%);
    --border: hsl(240 5.9% 90%);
    --input: hsl(240 5.9% 90%);
    --ring: hsl(240 10% 3.9%);
    --chart-1: hsl(12 76% 61%);
    --chart-2: hsl(173 58% 39%);
    --chart-3: hsl(197 37% 24%);
    --chart-4: hsl(43 74% 66%);
    --chart-5: hsl(27 87% 67%);
    --radius: 0.6rem;
    --sidebar-background: hsl(0 0% 98%);
    --sidebar-foreground: hsl(240 5.3% 26.1%);
    --sidebar-primary: hsl(240 5.9% 10%);
    --sidebar-primary-foreground: hsl(0 0% 98%);
    --sidebar-accent: hsl(240 4.8% 95.9%);
    --sidebar-accent-foreground: hsl(240 5.9% 10%);
    --sidebar-border: hsl(220 13% 91%);
    --sidebar-ring: hsl(217.2 91.2% 59.8%);
}

.dark {
    --background: hsl(240 10% 3.9%);
    --foreground: hsl(0 0% 98%);
    --card: hsl(240 10% 3.9%);
    --card-foreground: hsl(0 0% 98%);
    --popover: hsl(240 10% 3.9%);
    --popover-foreground: hsl(0 0% 98%);
    --primary: hsl(0 0% 98%);
    --primary-foreground: hsl(240 5.9% 10%);
    --secondary: hsl(240 3.7% 15.9%);
    --secondary-foreground: hsl(0 0% 98%);
    --muted: hsl(240 3.7% 15.9%);
    --muted-foreground: hsl(240 5% 64.9%);
    --accent: hsl(240 3.7% 15.9%);
    --accent-foreground: hsl(0 0% 98%);
    --destructive: hsl(0 62.8% 30.6%);
    --destructive-foreground: hsl(0 0% 98%);
    --border: hsl(240 3.7% 15.9%);
    --input: hsl(240 3.7% 15.9%);
    --ring: hsl(240 4.9% 83.9%);
    --chart-1: hsl(220 70% 50%);
    --chart-2: hsl(160 60% 45%);
    --chart-3: hsl(30 80% 55%);
    --chart-4: hsl(280 65% 60%);
    --chart-5: hsl(340 75% 55%);
    --sidebar-background: hsl(240 5.9% 10%);
    --sidebar-foreground: hsl(240 4.8% 95.9%);
    --sidebar-primary: hsl(224.3 76.3% 48%);
    --sidebar-primary-foreground: hsl(0 0% 100%);
    --sidebar-accent: hsl(240 3.7% 15.9%);
    --sidebar-accent-foreground: hsl(240 4.8% 95.9%);
    --sidebar-border: hsl(240 3.7% 15.9%);
    --sidebar-ring: hsl(217.2 91.2% 59.8%);
}

@theme inline {
    --color-background: var(--background);
    --color-foreground: var(--foreground);
    --color-card: var(--card);
    --color-card-foreground: var(--card-foreground);
    --color-popover: var(--popover);
    --color-popover-foreground: var(--popover-foreground);
    --color-primary: var(--primary);
    --color-primary-foreground: var(--primary-foreground);
    --color-secondary: var(--secondary);
    --color-secondary-foreground: var(--secondary-foreground);
    --color-muted: var(--muted);
    --color-muted-foreground: var(--muted-foreground);
    --color-accent: var(--accent);
    --color-accent-foreground: var(--accent-foreground);
    --color-destructive: var(--destructive);
    --color-destructive-foreground: var(--destructive-foreground);
    --color-border: var(--border);
    --color-input: var(--input);
    --color-ring: var(--ring);
    --color-chart-1: var(--chart-1);
    --color-chart-2: var(--chart-2);
    --color-chart-3: var(--chart-3);
    --color-chart-4: var(--chart-4);
    --color-chart-5: var(--chart-5);
    --radius-sm: calc(var(--radius) - 4px);
    --radius-md: calc(var(--radius) - 2px);
    --radius-lg: var(--radius);
    --radius-xl: calc(var(--radius) + 4px);
    --color-sidebar-ring: var(--sidebar-ring);
    --color-sidebar-border: var(--sidebar-border);
    --color-sidebar-accent-foreground: var(--sidebar-accent-foreground);
    --color-sidebar-accent: var(--sidebar-accent);
    --color-sidebar-primary-foreground: var(--sidebar-primary-foreground);
    --color-sidebar-primary: var(--sidebar-primary);
    --color-sidebar-foreground: var(--sidebar-foreground);
    --color-sidebar: var(--sidebar-background);
    --animate-accordion-down: accordion-down 0.2s ease-out;
    --animate-accordion-up: accordion-up 0.2s ease-out;
}
```

# FAQ

### Why not use another `xx` library?

- This library is built to be lightweight and follow a style convention similar to ShadCN.
- For more complex components, we recommend using other libraries like [Blazorise](https://blazorise.com/) or [MudBlazor](https://mudblazor.com/).

### Is this library free to use?

- Yes! This library is free to use for any Blazor project.

### Can I use this library with Blazor WebAssembly / Blazor Server / InteractiveAuto / MAUI?

- Yes! This library supports all Blazor hosting models.

### Can you add a specific component or feature?
- We are always open to suggestions, but we cannot guarantee that we will implement them.

### How do I report a bug?

- Please, open an issue on the [GitHub repository](https://github.com/pureblazor/components/issues/new/choose).
- Please, include as much information as possible, including what library version and browser you
  are using, and any steps to reproduce the issue.
