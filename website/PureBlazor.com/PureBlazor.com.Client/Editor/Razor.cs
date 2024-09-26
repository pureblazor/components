using System.Text.RegularExpressions;

namespace PureBlazor.com.Client.Editor;
public static class LanguageId
{
    public const string Asax = "asax";
    public const string Ashx = "ashx";
    public const string Aspx = "aspx";
    public const string AspxCs = "aspx(c#)";
    public const string CSharp = "c#";
    public const string FSharp = "f#";
    public const string Html = "html";
    public const string JavaScript = "javascript";
    public const string Json = "json";
    public const string PowerShell = "powershell";
    public const string Sql = "sql";
    public const string Xml = "xml";
    public const string Markdown = "markdown";
    public const string Razor = "razor";
}
public class CSharp : ILanguage
{
    public string Id => LanguageId.CSharp;

    public string Name => "C#";

    public string CssClassName => "csharp";

    public string FirstLinePattern => null;

    public IList<LanguageRule> Rules => new List<LanguageRule>
    {
        // new LanguageRule(
        //     @"//.*?$",
        //     new Dictionary<int, string> { { 0, RazorScopes.HtmlComment } }),
        // new LanguageRule(
        //     @"/\*.*?\*/",
        //     new Dictionary<int, string> { { 0, RazorScopes.HtmlComment } }),
        // new LanguageRule(
        //     @"'[^\n]*?'",
        //     new Dictionary<int, string> { { 0, RazorScopes.HtmlAttributeValue } }),
        // new LanguageRule(
        //     @"(?s)"".*?""",
        //     new Dictionary<int, string> { { 0, RazorScopes.HtmlAttributeValue } }),
        // new LanguageRule(
        //     @"\b([0-9]+(\.[0-9]+)?|0x[a-f0-9]+)\b",
        //     new Dictionary<int, string> { { 0, RazorScopes.HtmlEntity } }),
        // new LanguageRule(
        //     @"\b(bool|byte|char|decimal|double|float|int|long|sbyte|short|uint|ulong|ushort|void|object|string|class|enum|struct|public|private|internal|protected|static|readonly|sealed|const|event|explicit|extern|implicit|in|out|override|virtual|abstract|interface|new|operator|partial|unsafe|fixed|volatile)\b",
        //     new Dictionary<int, string> { { 0, RazorScopes.RazorDirective } }),
         new LanguageRule(
                                   @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(///)(?:\s*?(<[/a-zA-Z0-9\s""=]+>))*([^\r\n]*)",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.XmlDocTag },
                                           { 2, ScopeName.XmlDocTag },
                                           { 3, ScopeName.XmlDocComment },
                                       }),
                               new LanguageRule(
                                   @"(//.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment }
                                       }),
                               new LanguageRule(
                                   @"'[^\n]*?(?<!\\)'",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String }
                                       }),
                               new LanguageRule(
                                   @"(?s)@""(?:""""|.)*?""(?!"")",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.StringCSharpVerbatim }
                                       }),
                               new LanguageRule(
                                   @"(?s)(""[^\n]*?(?<!\\)"")",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String }
                                       }),
                               new LanguageRule(
                                   @"\[(assembly|module|type|return|param|method|field|property|event):[^\]""]*(""[^\n]*?(?<!\\)"")?[^\]]*\]",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword },
                                           { 2, ScopeName.String }
                                       }),
                               new LanguageRule(
                                   @"^\s*(\#define|\#elif|\#else|\#endif|\#endregion|\#error|\#if|\#line|\#pragma|\#region|\#undef|\#warning).*?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.PreprocessorKeyword }
                                       }),
                               new LanguageRule(
                                   @"\b(abstract|as|ascending|base|bool|break|by|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|descending|do|double|dynamic|else|enum|equals|event|explicit|extern|false|finally|fixed|float|for|foreach|from|get|goto|group|if|implicit|in|int|into|interface|internal|is|join|let|lock|long|namespace|new|null|object|on|operator|orderby|out|override|params|partial|private|protected|public|readonly|ref|return|sbyte|sealed|select|set|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|var|virtual|void|volatile|where|while|yield|async|await|warning|disable)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword }
                                       }),
                                   new LanguageRule(
                                   @"\b[0-9]{1,}\b",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Number }
                                       }),

                                   // return types
                                   new LanguageRule(
                                       @"\b(\w+)\s+(?=\w+\s*\()",
                                       new Dictionary<int, string> { { 0, ScopeName.Type } }),
                                   new LanguageRule(
                                       @"\b(\w+)\s+(?=\w+\s*\{)",
                                       new Dictionary<int, string> { { 0, ScopeName.Type } }),

                                   // method names
                                   new LanguageRule(
                                       @"(?<=\b\w+\s+)\w+(?=\s*\()",
                                       new Dictionary<int, string> { { 0, ScopeName.MethodName } }),

                                   // method type parameters
                                   new LanguageRule(
                                       @"(?<=\()\b\w+(?=\s+\w)",
                                       new Dictionary<int, string> { { 0, ScopeName.MethodParameter } }),

                                   new LanguageRule(
                                       @"(?<=\.)\b\w+(?=\s*\()",
                                       new Dictionary<int, string> { { 0, ScopeName.MethodCall } }),
    };

    public bool HasAlias(string lang)
    {
        switch (lang.ToLower())
        {
            case "cs":
            case "csharp":
                return true;
            default:
                return false;
        }
    }

    public override string ToString() => Name;
}
public class CaptureRule
{
    public int Index { get; set; }
    public string Scope { get; set; }
    public LanguageRule Rule { get; set; }
}

/// <summary>
/// Defines how ColorCode will parse the source code of a given language.
/// </summary>
public interface ILanguage
{
    /// <summary>
    /// Gets the identifier of the language (e.g., csharp).
    /// </summary>
    string Id { get; }

    /// <summary>
    /// Gets the first line pattern (regex) to use when determining if the language matches a source text.
    /// </summary>
    string FirstLinePattern { get; }

    /// <summary>
    /// Gets the "friendly" name of the language (e.g., C#).
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the collection of language rules in the language.
    /// </summary>
    IList<LanguageRule> Rules { get; }

    /// <summary>
    /// Get the CSS class name to use for a language
    /// </summary>
    string CssClassName { get; }

    /// <summary>
    /// Returns true if the specified string is an alias for the language
    /// </summary>
    bool HasAlias(string lang);
}

public class Razor : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Razor; }
        }

        public string Name
        {
            get { return "razor"; }
        }

        public string CssClassName
        {
            get { return "razor"; }
        }

        public string FirstLinePattern
        {
            get
            {
                return null;
            }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"@([A-Za-z_][A-Za-z0-9_]*)(\s+)?",
                                   new Dictionary<int, string>
                                   {
                                       { 0, RazorScopes.RazorDirective },
                                   }),
                               new LanguageRule(
                                   @"<([A-Za-z_][A-Za-z0-9_]*)(\s+)?",
                                   new Dictionary<int, string>
                                   {
                                       { 0, RazorScopes.BlazorComponent },
                                   }),
                               new LanguageRule(
                                   @"@([A-Za-z_][A-Za-z0-9_]*)(\s+)?",
                                   new Dictionary<int, string>
                                   {
                                       { 0, RazorScopes.RazorSyntax },
                                   }),
                               new LanguageRule(
                                   @"\<![ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t]*)\>",
                                   new Dictionary<int, string>
                                       {
                                           { 0, RazorScopes.HtmlComment },
                                       }),
                               new LanguageRule(
                                   @"(?i)(<!)(DOCTYPE)(?:\s+([a-zA-Z0-9]+))*(?:\s+(""[^""]*?""))*(>)",
                                   new Dictionary<int, string>
                                       {
                                           { 1, RazorScopes.HtmlTagDelimiter },
                                           { 2, RazorScopes.HtmlElementName },
                                           { 3, RazorScopes.HtmlAttributeName },
                                           { 4, RazorScopes.HtmlAttributeValue },
                                           { 5, RazorScopes.HtmlTagDelimiter }
                                       }),
                               new LanguageRule(
                                   @"(?xis)(<)
                                          (script)
                                          (?:
                                             [\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*([^\s\n""']+?)
                                            |[\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*(""[^\n]+?"")
                                            |[\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*('[^\n]+?')
                                            |[\s\n]+([a-z0-9-_]+) )*
                                          [\s\n]*
                                          (>)
                                          (.*?)
                                          (</)(script)(>)",
                                   new Dictionary<int, string>
                                       {
                                           { 1, RazorScopes.HtmlTagDelimiter },
                                           { 2, RazorScopes.HtmlElementName },
                                           { 3, RazorScopes.HtmlAttributeName },
                                           { 4, RazorScopes.HtmlOperator },
                                           { 5, RazorScopes.HtmlAttributeValue },
                                           { 6, RazorScopes.HtmlAttributeName },
                                           { 7, RazorScopes.HtmlOperator },
                                           { 8, RazorScopes.HtmlAttributeValue },
                                           { 9, RazorScopes.HtmlAttributeName },
                                           { 10, RazorScopes.HtmlOperator },
                                           { 11, RazorScopes.HtmlAttributeValue },
                                           { 12, RazorScopes.HtmlAttributeName },
                                           { 13, RazorScopes.HtmlTagDelimiter },
                                           { 14, string.Format("{0}{1}", RazorScopes.LanguagePrefix, LanguageId.JavaScript) },
                                           { 15, RazorScopes.HtmlTagDelimiter },
                                           { 16, RazorScopes.HtmlElementName },
                                           { 17, RazorScopes.HtmlTagDelimiter },
                                       }),
                               new LanguageRule(
                                   @"(?xis)(</?)
                                          (?: ([a-z][a-z0-9-]*)(:) )*
                                          ([a-z][a-z0-9-_]*)
                                          (?:
                                             [\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*([^\s\n""']+?)
                                            |[\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*(""[^\n]+?"")
                                            |[\s\n]+([a-z0-9-_]+)[\s\n]*(=)[\s\n]*('[^\n]+?')
                                            |[\s\n]+([a-z0-9-_]+) )*
                                          [\s\n]*
                                          (/?>)",
                                   new Dictionary<int, string>
                                       {
                                           { 1, RazorScopes.HtmlTagDelimiter },
                                           { 2, RazorScopes.HtmlElementName },
                                           { 3, RazorScopes.HtmlTagDelimiter },
                                           { 4, RazorScopes.HtmlElementName },
                                           { 5, RazorScopes.HtmlAttributeName },
                                           { 6, RazorScopes.HtmlOperator },
                                           { 7, RazorScopes.HtmlAttributeValue },
                                           { 8, RazorScopes.HtmlAttributeName },
                                           { 9, RazorScopes.HtmlOperator },
                                           { 10, RazorScopes.HtmlAttributeValue },
                                           { 11, RazorScopes.HtmlAttributeName },
                                           { 12, RazorScopes.HtmlOperator },
                                           { 13, RazorScopes.HtmlAttributeValue },
                                           { 14, RazorScopes.HtmlAttributeName },
                                           { 15, RazorScopes.HtmlTagDelimiter }
                                       }),
                               new LanguageRule(
                                   @"(?i)&\#?[a-z0-9]+?;",
                                   new Dictionary<int, string>
                                       {
                                           { 0, RazorScopes.HtmlEntity }
                                       }),

                               // new LanguageRule(
                               //     @"(?s)@code\s*\{.*?\}",
                               //     new Dictionary<int, string>
                               //     {
                               //         { 0, RazorScopes.RazorCodeBlock },
                               //     },
                               //     matches =>
                               //     {
                               //         var csharpRules = csharp.Rules.SelectMany(rule =>
                               //             rule.Captures.Select(capture => new CaptureRule
                               //             {
                               //                 Index = capture.Key,
                               //                 Scope = capture.Value,
                               //                 Rule = rule
                               //             })).ToList();
                               //
                               //         foreach (Match match in matches)
                               //         {
                               //             foreach (var captureRule in csharpRules)
                               //             {
                               //                 var capture = match.Captures[captureRule.Index];
                               //                 if (capture.Length > 0)
                               //                 {
                               //                     captureRule.Rule.Captures[captureRule.Index] = RazorScopes.RazorCodeBlock + "." + captureRule.Scope;
                               //                 }
                               //             }
                               //         }
                               //     })
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "htm":
                    return true;

                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

/// <summary>
/// Defines a single rule for a language. For instance a language rule might define string literals for a given language.
/// </summary>
public class LanguageRule
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LanguageRule"/> class.
    /// </summary>
    /// <param name="regex">The regular expression that defines what the language rule matches and captures.</param>
    /// <param name="captures">The scope indices and names of the regular expression's captures.</param>
    public LanguageRule(string regex,
        IDictionary<int, string> captures, Action<MatchCollection> matchesAction = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(regex);
        ArgumentNullException.ThrowIfNull(captures);
        if (captures.Count == 0)
        {
            throw new ArgumentException("captures is empty");
        }

        Regex = regex;
        Captures = captures;
        this.MatchesAction = matchesAction;

    }

    /// <summary>
    /// Gets the regular expression that defines what the language rule matches and captures.
    /// </summary>
    /// <value>The regular expression that defines what the language rule matches and captures.</value>
    public string Regex { get; private set; }
    /// <summary>
    /// Gets the scope indices and names of the regular expression's captures.
    /// </summary>
    /// <value>The scope indices and names of the regular expression's captures.</value>
    public IDictionary<int, string> Captures { get; private set; }

    public Action<MatchCollection> MatchesAction { get; private set; }

}
