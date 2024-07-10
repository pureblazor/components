using Microsoft.AspNetCore.Components.Web;

namespace Pure.Blazor.Components.Common;

public static class Keyboard
{
    public const string ArrowLeft = "ArrowLeft";
    public const string ArrowRight = "ArrowRight";
    public const string ArrowUp = "ArrowUp";
    public const string ArrowDown = "ArrowDown";
    public const string Enter = "Enter";
    public const string Space = " ";
    public const string Tab = "Tab";

    public static bool IsArrow(this KeyboardEventArgs e)
    {
        return IsArrowKey(e.Key);
    }

    public static bool IsHorizontalArrow(this KeyboardEventArgs e)
    {
        return IsHorizontalArrowKey(e.Key);
    }

    public static KeyboardDirection ToKeyboardDirection(this KeyboardEventArgs e)
    {
        return e.Key switch
        {
            ArrowLeft => KeyboardDirection.Backward,
            ArrowRight => KeyboardDirection.Forward,
            ArrowUp => KeyboardDirection.Up,
            ArrowDown => KeyboardDirection.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(e))
        };
    }

    private static bool IsArrowKey(string key) =>
        key is ArrowLeft or ArrowRight or ArrowUp or ArrowDown;

    private static bool IsHorizontalArrowKey(string key) =>
        key is ArrowLeft or ArrowRight;
}

public enum KeyboardDirection
{
    Up,
    Down,
    Backward,
    Forward
}
