namespace Pure.Blazor.Components.Buttons;

public class CustomStyles : PureStyles
{
    public CustomStyles() => Button.Variants[ButtonVariant.Default][Accent.Brand] =
        "bg-brand-200 hover:bg-brand-300 text-gray-700";
}
