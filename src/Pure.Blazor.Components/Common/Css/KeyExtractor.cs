namespace PureBlazor.Components;

public static class KeyExtractor
{
    /**
     * Special cases to handle separately
     *
     * none/inherit modifier should reset the other keyed styles
     * {elem}-none
     * {element}-inherit
     *
     * individual style overriding "general" style, e.g. py-4 when there is already p-2 or vice-versa
     */
    public static string ToCssKey(this string style)
    {
        var parts = style.Segment('-');
        var result = parts switch
        {
            [var elem, var dir and "l", _] => $"{elem}-{dir}-width",
            [var elem, var dir and "r", _] => $"{elem}-{dir}-width",
            [var elem, var dir and "t", _] => $"{elem}-{dir}-width",
            [var elem, var dir and "b", _] => $"{elem}-{dir}-width",
            [var elem, var dir and "l", _, ..] => $"{elem}-{dir}",
            [var elem, var dir and "r", _, ..] => $"{elem}-{dir}",
            [var elem, var dir and "t", _, ..] => $"{elem}-{dir}",
            [var elem, var dir and "b", _, ..] => $"{elem}-{dir}",
            [var elem, var attr, _, _] => $"{elem}-{attr}",
            [var elem, var axis and "x", _] => $"{elem}-{axis}",
            [var elem, var axis and "y", _] => $"{elem}-{axis}",
            [var elem, var axis and "w", _] => $"{elem}-{axis}",
            [var elem, var axis and "h", _] => $"{elem}-{axis}",
            [var elem, var attr and "opacity", _] => $"{elem}-{attr}",
            [var elem, var attr and "brightness", _] => $"{elem}-{attr}",
            [var elem, var attr and "contrast", _] => $"{elem}-{attr}",
            [var elem, var attr and "grayscale", _] => $"{elem}-{attr}",
            [var elem, var attr and "invert", var range] when int.TryParse(range, out _) => $"{elem}-{attr}",
            [var elem, var attr and "saturate", var range] when int.TryParse(range, out _) => $"{elem}-{attr}",
            ["not", "sr", "only"] => "sr",
            [var elem and "justify", var attr, _] => $"{elem}-{attr}",
            [_, var cols and "cols", _] => cols,
            [var col and "col", _, ..] => col,
            [var elem and "place", var attr, _] => $"{elem}-{attr}",
            [var elem, _, _] => elem,
            [var elem, var attr] when int.TryParse(attr, out _) => $"{elem}",
            ["select", _] => "select",
            ["backdrop", "invert", ..] => "backdrop-invert",
            ["flex", _] => "flex-direction",
            [var elem and "bg", "none"] => $"{elem}-color",
            [var elem, "solid"] => $"{elem}-style",
            [var elem, "dotted"] => $"{elem}-style",
            [var elem, "double"] => $"{elem}-style",
            [var elem, "dashed"] => $"{elem}-style",
            [var elem, "none"] => $"{elem}-style",
            [var elem, "white"] => $"{elem}-color",
            [var elem, "black"] => $"{elem}-color",
            [var elem, "left"] => $"{elem}-align",
            [var elem, "center"] => $"{elem}-align",
            [var elem, "right"] => $"{elem}-align",
            ["block"] => "display",
            ["inline-block"] => "display",
            ["inline"] => "display",
            ["flex"] => "display",
            ["inline-flex"] => "display",
            ["table"] => "display",
            ["inline-table"] => "display",
            ["table-caption"] => "display",
            ["table-cell"] => "display",
            ["table-column"] => "display",
            ["table-column-group"] => "display",
            ["table-footer-group"] => "display",
            ["table-header-group"] => "display",
            ["table-row-group"] => "display",
            ["table-row"] => "display",
            ["flow-root"] => "display",
            ["grid"] => "display",
            ["inline-grid"] => "display",
            ["contents"] => "display",
            ["list-item"] => "display",
            ["hidden"] => "display",
            ["uppercase"] => "text-transform",
            ["lowercase"] => "text-transform",
            ["capitalize"] => "text-transform",
            ["normal", "case"] => "text-transform",
            ["text", "ellipsis"] => "text-overflow",
            ["text", "clip"] => "text-overflow",
            ["truncate"] => "text-overflow",
            ["antialiased"] => "font-smoothing",
            ["subpixel", "antialiased"] => "font-smoothing",
            ["static"] => "position",
            ["fixed"] => "position",
            ["absolute"] => "position",
            ["relative"] => "position",
            ["sticky"] => "position",
            [var elem, _] => elem,
            _ => style
        };

        return result;
    }
}
