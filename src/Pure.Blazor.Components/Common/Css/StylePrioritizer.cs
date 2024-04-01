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
}
