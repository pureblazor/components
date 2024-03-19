namespace PureBlazor.Components;

public enum TextTransform
{
    Default,
    Uppercase,
    Lowercase,
    Capitalize
}

/// <summary>
///     Defines a base color with a shade.
/// </summary>
public class ColorWithShade
{
    public ColorWithShade(ColorWithShade baseColor, int shade)
    {
        BaseColor = baseColor.BaseColor;
        Shade = shade;
    }

    public ColorWithShade(string baseColor, int shade = 5)
    {
        BaseColor = baseColor;
        Shade = shade;
    }

    /// <summary>
    ///     The base color as a hex value.
    /// </summary>
    internal string BaseColor { get; set; }

    /// <summary>
    ///     The shade of the color from 0 - 10, where 10 is the darkest.
    /// </summary>
    public int Shade { get; set; }

    public ColorWithShade Zero => new(BaseColor, 0);

    public ColorWithShade One => new(BaseColor, 1);

    public ColorWithShade Two => new(BaseColor, 2);

    public ColorWithShade Three => new(BaseColor, 3);
    public ColorWithShade Four => new(BaseColor, 4);
    public ColorWithShade Five => new(BaseColor);
    public ColorWithShade Six => new(BaseColor, 6);
    public ColorWithShade Seven => new(BaseColor, 7);
    public ColorWithShade Eight => new(BaseColor, 8);
    public ColorWithShade Nine => new(BaseColor, 9);
    public ColorWithShade Ten => new(BaseColor, 10);
}


//[Tailwind("Brand")]
public static partial class TailwindColor { }

public partial class PureColor
{
    public static ColorWithShade Brand => new("brand");
    public static ColorWithShade Neutral => new("neutral");
    public static ColorWithShade Red => new("red");
}


public enum PureCardAlignment
{
    Top,
    Left
}
