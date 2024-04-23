using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class CustomTheme : PureTheme
{
    public CustomTheme() => Button.Variants[ButtonVariant.Default][Accent.Brand] =
        "bg-brand-200 hover:bg-brand-300 text-gray-700";
}
