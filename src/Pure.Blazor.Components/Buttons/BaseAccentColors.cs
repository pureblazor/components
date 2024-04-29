namespace Pure.Blazor.Components.Buttons;

/// <summary>
/// Base accent colors that have been checked for accessibility.
/// </summary>
public static class BaseAccentColors
{
    public const string Brand = $"{BrandAccentColors.Background} {BrandAccentColors.DarkBackgroundText}";
    public const string Warning = "bg-yellow-400 text-black";
    public const string Danger = $"{DangerAccentColors.Background} {DangerAccentColors.DarkBackgroundText}";
    public const string Success = "bg-green-500 text-black";
}