# Tailwind Customization

> [!NOTE]
> This documentation is incomplete.

You might want to add on styles that are not included in the default PureBlazor styles, such as utility classes or new
colors.

Below are a few options to integrate with your own code and layer the styles on top of the PureBlazor UI components.

### Use [dotnet-tailwind](https://github.com/codymullins/dotnet-tailwind) or the Tailwind CLI

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
