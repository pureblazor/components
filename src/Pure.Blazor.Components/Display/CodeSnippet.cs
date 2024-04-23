using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Pure.Blazor.Components.Display;

public class CodeSnippet : ComponentBase
{
    [Parameter] public string Content { get; set; } = "";
    private readonly HtmlLexer lexer = new ();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "pre");
        builder.AddAttribute(1, "class", "bg-gray-800 text-white p-4 rounded-lg font-mono text-sm overflow-x-auto");
        // builder.OpenElement(2, "code");
        var content = lexer.Highlight(Content);
        builder.AddMarkupContent(2, content);
        // builder.CloseElement();
        builder.CloseElement();
    }

    internal class HtmlLexer
    {
        private readonly string[] htmlPatterns = new string[]
        {
            @"<[^>]*>",
            @"&lt;[^&]*&gt;"
        };

        private readonly string[] razorPatterns = new string[]
        {
            @"@[^ ]*"
        };

        private readonly string[] csharpPatterns = new string[]
        {
            @"using", @"namespace", @"public", @"private", @"protected", @"internal", @"class", @"partial",
            @"const", @"var", @"new", @"void", @"async", @"await", @"Task", @"return", @"if", @"else", @"switch",
            @"case", @"default", @"foreach", @"in", @"for", @"while", @"do", @"break", @"continue", @"try",
            @"catch", @"finally", @"throw"
        };

        private readonly string[] cssPatterns = new string[]
        {
            @"@media", @"@keyframes", @"@import", @"@font-face", @"@supports", @"@page", @"@document", @"@charset",
            @"@namespace", @"@viewport", @"@counter-style", @"@font-feature-values", @"@swash", @"@ornaments",
            @"@annotation", @"@stylistic", @"@styleset", @"@character-variant", @"@historical-forms", @"@styleset",
            @"@annotation", @"@stylistic", @"@styleset", @"@character-variant", @"@historical-forms", @"@ornaments",
            @"@swash", @"@styleset", @"@annotation", @"@stylistic", @"@styleset", @"@character-variant",
            @"@historical-forms", @"@ornaments", @"@swash", @"@annotation", @"@stylistic", @"@styleset",
            @"@character-variant", @"@historical-forms", @"@ornaments", @"@swash", @"@annotation", @"@stylistic",
            @"@styleset", @"@character-variant", @"@historical-forms", @"@ornaments", @"@swash", @"@annotation",
            @"@stylistic", @"@styleset", @"@character-variant", @"@historical-forms", @"@ornaments", @"@swash",
            @"@annotation", @"@stylistic", @"@styleset", @"@character-variant", @"@historical-forms", @"@ornaments",
            @"@swash", @"@annotation", @"@stylistic", @"@styleset", @"@character-variant", @"@historical-forms",
            @"@ornaments", @"@swash", @"@annotation", @"@stylistic", @"@styleset", @"@character-variant",
            @"@historical-forms", @"@ornaments", @"@swash", @"@annotation", @"@stylistic", @"@styleset",
            @"@character-variant", @"@historical-forms", @"@ornaments", @"@swash", @"@annotation", @"@stylistic",
            @"@styleset", @"@character-variant", @"@historical-forms", @"@ornaments", @"@swash", @"@annotation"
        };

        private readonly string[] htmlAttributePatterns = new string[]
        {
            @"class", @"id", @"name", @"style", @"href", @"src", @"alt", @"title", @"aria-[^ ]*", @"data-[^ ]*"
        };

        internal string Highlight(string input)
        {
            var builder = new StringBuilder();
            var reader = new StringReader(input);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var words = line.Split(' ');
                foreach (var word in words)
                {
                    if (htmlPatterns.Any(p => Regex.IsMatch(word, p)))
                    {
                        builder.Append($"<span class=\"html-tag\">{word}</span> ");
                    }
                    else if (razorPatterns.Any(p => Regex.IsMatch(word, p)))
                    {
                        builder.Append($"<span class=\"razor-tag\">{word}</span> ");
                    }
                    else if (csharpPatterns.Any(p => Regex.IsMatch(word, p)))
                    {
                        builder.Append($"<span class=\"csharp-keyword\">{word}</span> ");
                    }
                    else if (cssPatterns.Any(p => Regex.IsMatch(word, p)))
                    {
                        builder.Append($"<span class=\"css-keyword\">{word}</span> ");
                    }
                    else if (htmlAttributePatterns.Any(p => Regex.IsMatch(word, p)))
                    {
                        builder.Append($"<span class=\"html-attribute\">{word}</span> ");
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

}
