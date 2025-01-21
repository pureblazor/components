using System.Text;

namespace Pure.Blazor.Components;

public class SyntaxHighligher
{
    /// <summary>
    /// Returns a highlighted version of the code using CSS classes.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="language"></param>
    /// <returns></returns>
    public string Highlight(string code, string language)
    {
        switch (language)
        {
            case "csharp":
                return HighlightCsharp(code);
            case "html":
                return HighlightHtml(code);
            case "xml":
                return HighlightXml(code);
            case "razor":
                return HighlightRazor(code);
            default:
                return code;
        }
    }

    private string HighlightXml(string code)
    {
        var builder = new StringBuilder();
        var reader = new StringReader(code);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                if (word.StartsWith("<"))
                {
                    builder.Append($"<span class=\"xml-tag\">{word}</span> ");
                }
                else
                {
                    builder.Append($"{word} ");
                }
            }

            builder.Append("/n");
        }

        return builder.ToString();
    }

    private string HighlightRazor(string code)
    {
        var builder = new StringBuilder();
        var reader = new StringReader(code);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                if (word.StartsWith("@"))
                {
                    builder.Append($"<span class=\"razor-directive\">{word}</span> ");
                }
                else
                {
                    builder.Append($"{word} ");
                }
            }

            builder.Append("/n");
        }

        return builder.ToString();
    }

    private string HighlightCsharp(string code)
    {
        var keywords = new HashSet<string>
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class",
            "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event",
            "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit",
            "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object",
            "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref",
            "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using",
            "virtual", "void", "volatile", "while"
        };

        var builder = new StringBuilder();
        var reader = new StringReader(code);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                if (keywords.Contains(word))
                {
                    builder.Append($"<span class=\"csharp-keyword\">{word}</span> ");
                }
                else
                {
                    builder.Append($"{word} ");
                }
            }

            builder.Append("<br>");
        }

        return builder.ToString();
    }

    private string HighlightHtml(string code)
    {
        var builder = new StringBuilder();
        var reader = new StringReader(code);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var words = line.Split(' ');
            foreach (var word in words)
            {
                if (word.StartsWith("<"))
                {
                    builder.Append($"<span class=\"html-tag\">{word}</span> ");
                }
                else
                {
                    builder.Append($"{word} ");
                }
            }

            builder.Append("<br>");
        }

        return builder.ToString();
    }
}
