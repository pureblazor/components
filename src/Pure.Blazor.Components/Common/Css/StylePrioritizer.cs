using System.Buffers;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Pure.Blazor.Components.Common.Css;

public class StylePrioritizer
{
    /// <summary>
    ///     Use the first segment as the key for Tailwind styles.
    ///     TODO: How to handle inverses? e.g. hidden vs block, visible vs invisible
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    [Benchmark]
    [Arguments("bg-gray-100")]
    public string GetKeyFromStyle(string style)
    {
        if (style.Contains('-'))
        {
            var parts = style.Split('-');

            // use the first segment as the key if this style is a standard [modifier]:{elem}-{color}-{shade}
            // otherwise we don't support prioritizing that style for this component
            return parts.Length is 2 or 3 ? parts[0] : style;
        }

        return style;
    }

    [Benchmark]
    [Arguments("bg-gray-100", "bg-gray-200")]
    [Arguments("bg-gray-100", "border-gray-200")]
    [Arguments("border-gray-100 bg-white text-gray-900", "border-gray-200 hover:border-gray-300")]
    [Arguments("border-gray-100 bg-white text-gray-900 hover:text-gray-400 border-1 divide-y",
        "border-gray-200 hover:border-gray-300 opacity-1 hover:opacity-0")]
    public string PrioritizeStyles(string defaultStyles, string userStyles)
    {
        var userStylesArray = userStyles.Split(' ');
        var userStylesDict = userStylesArray.ToDictionary(GetKeyFromStyle, s => s);

        var result = new StringBuilder(defaultStyles.Length + userStyles.Length);
        var buffer = ArrayPool<char>.Shared.Rent(defaultStyles.Length);

        try
        {
            defaultStyles.AsSpan().CopyTo(buffer);
            var start = 0;
            for (var i = 0; i < defaultStyles.Length; i++)
            {
                if (buffer[i] == ' ')
                {
                    var style = new string(buffer, start, i - start);
                    if (!userStylesDict.ContainsKey(GetKeyFromStyle(style)))
                    {
                        result.Append(style);
                        result.Append(' ');
                    }

                    start = i + 1;
                }
            }

            // Add the last style if it's not in user styles
            var lastStyle = new string(buffer, start, defaultStyles.Length - start);
            if (!userStylesDict.ContainsKey(GetKeyFromStyle(lastStyle)))
            {
                result.Append(lastStyle);
                result.Append(' ');
            }

            // Add all user styles
            result.Append(userStyles);

            return result.ToString();
        }
        finally
        {
            ArrayPool<char>.Shared.Return(buffer);
        }
    }
    // public string PrioritizeStyles(string defaultStyles, string userStyles)
    // {
    //     var pool = ArrayPool<char>.Shared;
    //     var userStylesArray = userStyles.Split(' ');
    //     var userStylesDict = userStylesArray.ToDictionary(GetKeyFromStyle, s => s);
    //     var defaultStylesArray = defaultStyles.Split(' ');
    //     var finalStyles = new List<string>();
    //
    //     foreach (var style in defaultStylesArray)
    //     {
    //         var defaultStyleKey = GetKeyFromStyle(style);
    //         if (userStylesDict.TryGetValue(defaultStyleKey, out var userStyle))
    //         {
    //             finalStyles.Add(userStyle);
    //         }
    //         else
    //         {
    //             finalStyles.Add(style);
    //         }
    //     }
    //
    //     foreach (var userStyle in userStylesDict.Values)
    //     {
    //         if (!finalStyles.Contains(userStyle))
    //         {
    //             finalStyles.Add(userStyle);
    //         }
    //     }
    //
    //     var result = string.Join(' ', finalStyles);
    //
    //     // Return the arrays to the pool
    //     pool.Return(userStylesArray);
    //     pool.Return(defaultStylesArray);
    //
    //     return result;
    // }
}

public class SegmentBenchmarks
{
    [Benchmark(Baseline = true)]
    public void NoSeparator() => "foo".Segment(':');

    [Benchmark]
    public void Single() => "bg-gray-100".Segment('-');

    [Benchmark]
    public void OnlySeparators() => "foo:bar:baz".Segment(':');

    [Benchmark]
    public void Parens() => "a:(b:c):d".Segment(':');

    [Benchmark]
    public void Brackets() => "a:[b:c]:d".Segment(':');

    [Benchmark]
    public void CurlyBraces() => "a:{b:c}:d".Segment(':');

    [Benchmark]
    public void Var() => "var(--a, 0 0 1px rgb(0, 0, 0)), 0 0 1px rgb(0, 0, 0)".Segment(',');
}

public static class Segmentor
{
    public static Stack<string> Segment(this string input, char separator)
    {
        var closingBracketStack = new Stack<char>();
        var parts = new Stack<string>();
        var lastPos = 0;

        for (var idx = 0; idx < input.Length; idx++)
        {
            var charValue = input[idx];

            if (closingBracketStack.Count == 0 && charValue == separator)
            {
                parts.Push(input.Substring(lastPos, idx - lastPos));
                lastPos = idx + 1;
                continue;
            }

            switch (charValue)
            {
                case '\\':
                    idx += 1;
                    break;
                case '(':
                    closingBracketStack.Push(')');
                    break;
                case '[':
                    closingBracketStack.Push(']');
                    break;
                case '{':
                    closingBracketStack.Push('}');
                    break;
                case ')':
                case ']':
                case '}':
                    if (closingBracketStack.Count > 0 && charValue == closingBracketStack.Peek())
                    {
                        closingBracketStack.Pop();
                    }

                    break;
            }
        }

        parts.Push(input[lastPos..]);

        return parts;
    }
}
