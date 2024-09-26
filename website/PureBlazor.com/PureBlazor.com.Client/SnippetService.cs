using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using PureBlazor.com.Client.Editor;
using ILanguage = PureBlazor.com.Client.Editor.ILanguage;
using ScopeName = PureBlazor.com.Client.Editor.ScopeName;

namespace PureBlazor.com.Client;

public class SnippetService
{
    private readonly HtmlClassFormatter formatter = new(TailwindStyleDictionary.DefaultLight);

    public MarkupString LoadSnippetFromSource(string source, ILanguage language)
    {
        return (MarkupString)GetCodeBlock(source, language);
    }

    public MarkupString LoadSnippetFromFile(string name, ILanguage language)
    {
        var path = $"wwwroot/snippets/{name}";
        var markdown = File.ReadAllText(path);
        return (MarkupString)GetCodeBlock(markdown, language);
    }

    public MarkupString LoadSnippet(string name, ILanguage language)
    {
        var path = $"wwwroot/snippets/{name}";
        var markdown = File.ReadAllText(path);
        return (MarkupString)GetCodeBlock(markdown, language);
    }

    private string GetCodeBlock(string code, ILanguage language)
    {
        var html = formatter.GetHtmlString(code, language);
        return html;
    }
}

public static class Guard
{
    public static void ArgNotNull(object arg, string paramName)
    {
        if (arg == null)
            throw new ArgumentNullException(paramName);
    }

    public static void ArgNotNullAndNotEmpty(string arg, string paramName)
    {
        if (arg == null)
            throw new ArgumentNullException(paramName);

        if (string.IsNullOrEmpty(arg))
            throw new ArgumentException(string.Format("The {0} argument value must not be empty.", paramName), paramName);
    }

    public static void EnsureParameterIsNotNullAndNotEmpty<TKey, TValue>(IDictionary<TKey, TValue> parameter, string parameterName)
    {
        if (parameter == null || parameter.Count == 0)
            throw new ArgumentNullException(parameterName);
    }

    public static void ArgNotNullAndNotEmpty<T>(IList<T> arg, string paramName)
    {
        if (arg == null)
            throw new ArgumentNullException(paramName);

        if (arg.Count == 0)
            throw new ArgumentException(string.Format("The {0} argument value must not be empty.", paramName), paramName);
    }
}
public class Scope
{
    public Scope(string name,
        int index,
        int length)
    {
        Guard.ArgNotNullAndNotEmpty(name, "name");

        Name = name;
        Index = index;
        Length = length;
        Children = new List<Scope>();
    }

    public IList<Scope> Children { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
    public Scope Parent { get; set; }
    public string Name { get; set; }

    public void AddChild(Scope childScope)
    {
        if (childScope.Parent != null)
            throw new InvalidOperationException("The child scope already has a parent.");

        childScope.Parent = this;

        Children.Add(childScope);
    }
}
public class TextInsertion
{
    public virtual int Index { get; set; }
    public virtual string Text { get; set; }
    public virtual Scope Scope { get; set; }
}

    /// <summary>
    /// Defines the styling for a given scope.
    /// </summary>
    public class Style
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Style"/> class.
        /// </summary>
        /// <param name="scopeName">The name of the scope the style defines.</param>
        public Style(string scopeName)
        {
            Guard.ArgNotNullAndNotEmpty(scopeName, "scopeName");

            ScopeName = scopeName;
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>The background color.</value>
        public string Background { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        /// <value>The foreground color.</value>
        public string Foreground { get; set; }

        /// <summary>
        /// Gets or sets the name of the scope the style defines.
        /// </summary>
        /// <value>The name of the scope the style defines.</value>
        public string ScopeName { get; set; }

        /// <summary>
        /// Gets or sets the reference name of the scope, such as in CSS.
        /// </summary>
        /// <value>The plain text Reference name.</value>
        public string ReferenceName { get; set; }

        /// <summary>
        /// Gets or sets italic font style.
        /// </summary>
        /// <value>True if italic.</value>
        public bool Italic { get; set; }

        /// <summary>
        /// Gets or sets bold font style.
        /// </summary>
        /// <value>True if bold.</value>
        public bool Bold { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        /// <remarks>
        /// Returns the scope name if specified, or String.Empty otherwise.
        /// </remarks>
        public override string ToString()
        {
            return ScopeName ?? string.Empty;
        }
    }
/// <summary>
/// A dictionary of <see cref="Style" /> instances, keyed by the styles' scope name.
/// </summary>
public partial class StyleDictionary : KeyedCollection<string, Style>
{
    /// <summary>
    /// When implemented in a derived class, extracts the key from the specified element.
    /// </summary>
    /// <param name="item">The element from which to extract the key.</param>
    /// <returns>The key for the specified element.</returns>
    protected override string GetKeyForItem(Style item)
    {
        return item.ScopeName;
    }

    public const string Blue = "#FF0000FF";
    public const string White = "#FFFFFFFF";
    public const string Black = "#FF000000";
    public const string DullRed = "#FFA31515";
    public const string Yellow = "#FFFFFF00";
    public const string Green = "#FF008000";
    public const string PowderBlue = "#FFB0E0E6";
    public const string Teal = "#FF008080";
    public const string Gray = "#FF808080";
    public const string Navy = "#FF000080";
    public const string OrangeRed = "#FFFF4500";
    public const string Purple = "#FF800080";
    public const string Red = "#FFFF0000";
    public const string MediumTurqoise = "FF48D1CC";
    public const string Magenta = "FFFF00FF";
    public const string OliveDrab = "#FF6B8E23";
    public const string DarkOliveGreen = "#FF556B2F";
    public const string DarkCyan = "#FF008B8B";
    public const string DarkOrange = "#FFFF8700";
    public const string BrightGreen = "#FF00d700";
    public const string BrightPurple = "#FFaf87ff";
}
public class CompiledLanguage
{
    public CompiledLanguage(string id,
        string name,
        Regex regex,
        IList<string> captures)
    {
        Guard.ArgNotNullAndNotEmpty(id, "id");
        Guard.ArgNotNullAndNotEmpty(name, "name");
        Guard.ArgNotNull(regex, "regex");
        Guard.ArgNotNullAndNotEmpty(captures, "captures");

        Id = id;
        Name = name;
        Regex = regex;
        Captures = captures;
    }

    public IList<string> Captures { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public Regex Regex { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
public interface ILanguageCompiler
{
    CompiledLanguage Compile(ILanguage language);
}
public class LanguageCompiler : ILanguageCompiler
    {
        private static readonly Regex numberOfCapturesRegex = new Regex(@"(?x)(?<!(\\|(?!\\)\(\?))\((?!\?)", RegexOptions.Compiled);
        private readonly Dictionary<string, CompiledLanguage> compiledLanguages;
        private readonly ReaderWriterLockSlim compileLock;

        public LanguageCompiler(Dictionary<string, CompiledLanguage> compiledLanguages, ReaderWriterLockSlim compileLock)
        {
            this.compiledLanguages = compiledLanguages;
            this.compileLock = compileLock;
        }

        public CompiledLanguage Compile(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            if (string.IsNullOrEmpty(language.Id))
                throw new ArgumentException("The language identifier must not be null.", "language");

            CompiledLanguage compiledLanguage;

            compileLock.EnterReadLock();
            try
            {
                // for performance reasons we should first try with
                // only a read lock since the majority of the time
                // it'll be created already and upgradeable lock blocks
                if (compiledLanguages.ContainsKey(language.Id))
                    return compiledLanguages[language.Id];
            }
            finally
            {
                compileLock.ExitReadLock();
            }

            compileLock.EnterUpgradeableReadLock();
            try
            {
                if (compiledLanguages.ContainsKey(language.Id))
                    compiledLanguage = compiledLanguages[language.Id];
                else
                {
                    compileLock.EnterWriteLock();

                    try
                    {
                        if (string.IsNullOrEmpty(language.Name))
                            throw new ArgumentException("The language name must not be null or empty.", "language");

                        if (language.Rules == null || language.Rules.Count == 0)
                            throw new ArgumentException("The language rules collection must not be empty.", "language");

                        compiledLanguage = CompileLanguage(language);

                        compiledLanguages.Add(compiledLanguage.Id, compiledLanguage);
                    }
                    finally
                    {
                        compileLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                compileLock.ExitUpgradeableReadLock();
            }

            return compiledLanguage;
        }

        private static CompiledLanguage CompileLanguage(ILanguage language)
        {
            string id = language.Id;
            string name = language.Name;

            CompileRules(language.Rules, out Regex regex, out IList<string> captures);

            return new CompiledLanguage(id, name, regex, captures);
        }

        private static void CompileRules(IList<LanguageRule> rules, out Regex regex, out IList<string> captures)
        {
            StringBuilder regexBuilder = new StringBuilder();
            captures = new List<string>();

            regexBuilder.AppendLine("(?x)");
            captures.Add(null);

            CompileRule(rules[0], regexBuilder, captures, true);

            for (int i = 1; i < rules.Count; i++)
                CompileRule(rules[i], regexBuilder, captures, false);

            regex = new Regex(regexBuilder.ToString());
        }

        private static void CompileRule(LanguageRule languageRule, StringBuilder regex, ICollection<string> captures, bool isFirstRule)
        {
            if (!isFirstRule)
            {
                regex.AppendLine();
                regex.AppendLine();
                regex.AppendLine("|");
                regex.AppendLine();
            }

            regex.AppendFormat("(?-xis)(?m)({0})(?x)", languageRule.Regex);

            int numberOfCaptures = GetNumberOfCaptures(languageRule.Regex);

            for (int i = 0; i <= numberOfCaptures; i++)
            {
                string scope = null;

                foreach (int captureIndex in languageRule.Captures.Keys)
                {
                    if (i == captureIndex)
                    {
                        scope = languageRule.Captures[captureIndex];
                        break;
                    }
                }

                captures.Add(scope);
            }
        }

        private static int GetNumberOfCaptures(string regex)
        {
            return numberOfCapturesRegex.Matches(regex).Count;
        }
    }
public interface ILanguageRepository
{
    IEnumerable<ILanguage> All { get; }
    ILanguage FindById(string languageId);
    void Load(ILanguage language);
}
public static class ExtensionMethods
{
    public static void SortStable<T>(this IList<T> list,
        Comparison<T> comparison)
    {
        Guard.ArgNotNull(list, "list");

        int count = list.Count;

        for (int j = 1; j < count; j++)
        {
            T key = list[j];

            int i = j - 1;
            for (; i >= 0 && comparison(list[i], key) > 0; i--)
            {
                list[i + 1] = list[i];
            }

            list[i + 1] = key;
        }
    }
}
public class LanguageParser : ILanguageParser
    {
        private readonly ILanguageCompiler languageCompiler;
        private readonly ILanguageRepository languageRepository;

        public LanguageParser(ILanguageCompiler languageCompiler,
                              ILanguageRepository languageRepository)
        {
            this.languageCompiler = languageCompiler;
            this.languageRepository = languageRepository;
        }

        public void Parse(string sourceCode,
                          ILanguage language,
                          Action<string, IList<Scope>> parseHandler)
        {
            if (string.IsNullOrEmpty(sourceCode))
                return;

            CompiledLanguage compiledLanguage = languageCompiler.Compile(language);

            Parse(sourceCode, compiledLanguage, parseHandler);
        }

        private void Parse(string sourceCode,
                           CompiledLanguage compiledLanguage,
                           Action<string, IList<Scope>> parseHandler)
        {
            Match regexMatch = compiledLanguage.Regex.Match(sourceCode);

            if (!regexMatch.Success)
                parseHandler(sourceCode, new List<Scope>());
            else
            {
                int currentIndex = 0;

                while (regexMatch.Success)
                {
                    string sourceCodeBeforeMatch = sourceCode.Substring(currentIndex, regexMatch.Index - currentIndex);
                    if (!string.IsNullOrEmpty(sourceCodeBeforeMatch))
                        parseHandler(sourceCodeBeforeMatch, new List<Scope>());

                    string matchedSourceCode = sourceCode.Substring(regexMatch.Index, regexMatch.Length);
                    if (!string.IsNullOrEmpty(matchedSourceCode))
                    {
                        List<Scope> capturedStylesForMatchedFragment = GetCapturedStyles(regexMatch, regexMatch.Index, compiledLanguage);
                        List<Scope> capturedStyleTree = CreateCapturedStyleTree(capturedStylesForMatchedFragment);
                        parseHandler(matchedSourceCode, capturedStyleTree);
                    }

                    currentIndex = regexMatch.Index + regexMatch.Length;
                    regexMatch = regexMatch.NextMatch();
                }

                string sourceCodeAfterAllMatches = sourceCode.Substring(currentIndex);
                if (!string.IsNullOrEmpty(sourceCodeAfterAllMatches))
                    parseHandler(sourceCodeAfterAllMatches, new List<Scope>());
            }
        }

        private static List<Scope> CreateCapturedStyleTree(IList<Scope> capturedStyles)
        {
            capturedStyles.SortStable((x, y) => x.Index.CompareTo(y.Index));

            var capturedStyleTree = new List<Scope>(capturedStyles.Count);
            Scope currentScope = null;

            foreach (Scope capturedStyle in capturedStyles)
            {
                if (currentScope == null)
                {
                    capturedStyleTree.Add(capturedStyle);
                    currentScope = capturedStyle;
                    continue;
                }

                AddScopeToNestedScopes(capturedStyle, ref currentScope, capturedStyleTree);
            }

            return capturedStyleTree;
        }

        private static void AddScopeToNestedScopes(Scope scope,
                                                   ref Scope currentScope,
                                                   ICollection<Scope> capturedStyleTree)
        {
            if (scope.Index >= currentScope.Index && (scope.Index + scope.Length <= currentScope.Index + currentScope.Length))
            {
                currentScope.AddChild(scope);
                currentScope = scope;
            }
            else
            {
                currentScope = currentScope.Parent;

                if (currentScope != null)
                    AddScopeToNestedScopes(scope, ref currentScope, capturedStyleTree);
                else
                    capturedStyleTree.Add(scope);
            }
        }


        private List<Scope> GetCapturedStyles(Match regexMatch,
                                                      int currentIndex,
                                                      CompiledLanguage compiledLanguage)
        {
            var capturedStyles = new List<Scope>();

            for (int i = 0; i < regexMatch.Groups.Count; i++)
            {
                Group regexGroup = regexMatch.Groups[i];
                if (regexGroup.Length > 0 && i < compiledLanguage.Captures.Count) {  //note: i can be >= Captures.Count due to named groups; these do capture a group but always get added after all non-named groups (which is why we do not count them in numberOfCaptures)
                    string styleName = compiledLanguage.Captures[i];
                    if (!String.IsNullOrEmpty(styleName)) {
                        foreach (Capture regexCapture in regexGroup.Captures)
                            AppendCapturedStylesForRegexCapture(regexCapture, currentIndex, styleName, capturedStyles);
                    }
                }
            }

            return capturedStyles;
        }

        private void AppendCapturedStylesForRegexCapture(Capture regexCapture,
                                                         int currentIndex,
                                                         string styleName,
                                                         ICollection<Scope> capturedStyles)
        {
            if (styleName.StartsWith(ScopeName.LanguagePrefix))
            {
                string nestedGrammarId = styleName.Substring(1);
                AppendCapturedStylesForNestedLanguage(regexCapture, regexCapture.Index - currentIndex, nestedGrammarId, capturedStyles);
            }
            else
                capturedStyles.Add(new Scope(styleName, regexCapture.Index - currentIndex, regexCapture.Length));
        }

        private void AppendCapturedStylesForNestedLanguage(Capture regexCapture,
                                                           int offset,
                                                           string nestedLanguageId,
                                                           ICollection<Scope> capturedStyles)
        {
            ILanguage nestedLanguage = languageRepository.FindById(nestedLanguageId);

            if (nestedLanguage == null)
                throw new InvalidOperationException("The nested language was not found in the language repository.");
            else
            {
                CompiledLanguage nestedCompiledLanguage = languageCompiler.Compile(nestedLanguage);

                Match regexMatch = nestedCompiledLanguage.Regex.Match(regexCapture.Value, 0, regexCapture.Value.Length);

                if (!regexMatch.Success)
                    return;
                else
                {
                    while (regexMatch.Success)
                    {
                        List<Scope> capturedStylesForMatchedFragment = GetCapturedStyles(regexMatch, 0, nestedCompiledLanguage);
                        List<Scope> capturedStyleTree = CreateCapturedStyleTree(capturedStylesForMatchedFragment);

                        foreach (Scope nestedCapturedStyle in capturedStyleTree)
                        {
                            IncreaseCapturedStyleIndicies(capturedStyleTree, offset);
                            capturedStyles.Add(nestedCapturedStyle);
                        }

                        regexMatch = regexMatch.NextMatch();
                    }
                }
            }
        }

        private static void IncreaseCapturedStyleIndicies(IList<Scope> capturedStyles,
                                                          int amountToIncrease)
        {
            for (int i = 0; i < capturedStyles.Count; i++)
            {
                Scope scope = capturedStyles[i];

                scope.Index += amountToIncrease;

                if (scope.Children.Count > 0)
                    IncreaseCapturedStyleIndicies(scope.Children, amountToIncrease);
            }
        }
    }
public class LanguageRepository : ILanguageRepository
{
    private readonly Dictionary<string, ILanguage> loadedLanguages;
    private readonly ReaderWriterLockSlim loadLock;

    public LanguageRepository(Dictionary<string, ILanguage> loadedLanguages)
    {
        this.loadedLanguages = loadedLanguages;
        loadLock = new ReaderWriterLockSlim();
    }

    public IEnumerable<ILanguage> All
    {
        get { return loadedLanguages.Values; }
    }

    public ILanguage FindById(string languageId)
    {
        Guard.ArgNotNullAndNotEmpty(languageId, "languageId");

        ILanguage language = null;

        loadLock.EnterReadLock();

        try
        {
            // If we have a matching name for the language then use it
            // otherwise check if any languages have that string as an
            // alias. For example: "js" is an alias for Javascript.
            language = loadedLanguages.FirstOrDefault(x => (x.Key.ToLower() == languageId.ToLower()) ||
                                                           (x.Value.HasAlias(languageId))).Value;
        }
        finally
        {
            loadLock.ExitReadLock();
        }

        return language;
    }

    public void Load(ILanguage language)
    {
        Guard.ArgNotNull(language, "language");

        if (string.IsNullOrEmpty(language.Id))
            throw new ArgumentException("The language identifier must not be null or empty.", "language");

        loadLock.EnterWriteLock();

        try
        {
            loadedLanguages[language.Id] = language;
        }
        finally
        {
            loadLock.ExitWriteLock();
        }
    }
}
public class PowerShell : ILanguage
    {
        public string Id
        {
            get { return LanguageId.PowerShell; }
        }

        public string Name
        {
            get { return "PowerShell"; }
        }

        public string CssClassName
        {
            get { return "powershell"; }
        }

        public string FirstLinePattern
        {
            get { return null; }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"(?s)(<\#.*?\#>)",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Comment}
                                       }),
                               new LanguageRule(
                                   @"(\#.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Comment}
                                       }),
                               new LanguageRule(
                                   @"'[^\n]*?(?<!\\)'",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.String}
                                       }),
                               new LanguageRule(
                                   @"(?s)@"".*?""@",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.StringCSharpVerbatim}
                                       }),
                               new LanguageRule(
                                   @"(?s)(""[^\n]*?(?<!`)"")",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.String}
                                       }),
                               new LanguageRule(
                                   @"\$(?:[\d\w\-]+(?::[\d\w\-]+)?|\$|\?|\^)",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellVariable}
                                       }),
                               new LanguageRule(
                                   @"\${[^}]+}",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellVariable}
                                       }),
                               new LanguageRule(
                                   @"(?i)\b(begin|break|catch|continue|data|do|dynamicparam|elseif|else|end|exit|filter|finally|foreach|for|from|function|if|in|param|process|return|switch|throw|trap|try|until|while)\b",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.Keyword}
                                       }),
                               new LanguageRule(
                                   @"\b(\w+\-\w+)\b",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.PowerShellCommand}
                                       }),
                               new LanguageRule(
                                   @"-(?:c|i)?(?:eq|ne|gt|ge|lt|le|notlike|like|notmatch|match|notcontains|contains|replace)",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellOperator}
                                       }
                                   ),
                               new LanguageRule(
                                   @"-(?:band|and|as|join|not|bxor|xor|bor|or|isnot|is|split)",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellOperator}
                                       }
                                   ),
                               new LanguageRule(
                                   @"-\w+\d*\w*",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellParameter}
                                       }
                                   ),
                               new LanguageRule(
                                   @"(?:\+=|-=|\*=|/=|%=|=|\+\+|--|\+|-|\*|/|%|\||,)",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellOperator}
                                       }
                                   ),
                               new LanguageRule(
                                   @"(?:\>\>|2\>&1|\>|2\>\>|2\>)",
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.PowerShellOperator}
                                       }
                                   ),
                               new LanguageRule(
                                   @"(?is)\[(cmdletbinding|alias|outputtype|parameter|validatenotnull|validatenotnullorempty|validatecount|validateset|allownull|allowemptycollection|allowemptystring|validatescript|validaterange|validatepattern|validatelength|supportswildcards)[^\]]+\]",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.PowerShellAttribute}
                                       }),
                               new LanguageRule(
                                   @"(\[)([^\]]+)(\])(::)?",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.PowerShellOperator},
                                           {2, ScopeName.PowerShellType},
                                           {3, ScopeName.PowerShellOperator},
                                           {4, ScopeName.PowerShellOperator}
                                       })
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "posh":
                case "ps1":
                case "pwsh":
                    return true;

                default:
                    return false;
            }
        }
    }
public static class Languages
    {
        internal static readonly LanguageRepository LanguageRepository;
        internal static readonly Dictionary<string, ILanguage> LoadedLanguages;
        internal static Dictionary<string, CompiledLanguage> CompiledLanguages;
        internal static ReaderWriterLockSlim CompileLock;

        static Languages()
        {
            LoadedLanguages = new Dictionary<string, ILanguage>();
            CompiledLanguages = new Dictionary<string, CompiledLanguage>();
            LanguageRepository = new LanguageRepository(LoadedLanguages);
            CompileLock = new ReaderWriterLockSlim();
            Load<Razor>();
            Load<CSharp>();
            Load<PowerShell>();
        }

        /// <summary>
        /// Gets an enumerable list of all loaded languages.
        /// </summary>
        public static IEnumerable<ILanguage> All
        {
            get { return LanguageRepository.All; }
        }

        /// <summary>
        /// Language support for ASP.NET HTTP Handlers (.ashx files).
        /// </summary>
        /// <value>Language support for ASP.NET HTTP Handlers (.ashx files).</value>
        public static ILanguage Ashx
        {
            get { return LanguageRepository.FindById(LanguageId.Ashx); }
        }

        /// <summary>
        /// Language support for ASP.NET application files (.asax files).
        /// </summary>
        /// <value>Language support for ASP.NET application files (.asax files).</value>
        public static ILanguage Asax
        {
            get { return LanguageRepository.FindById(LanguageId.Asax); }
        }

        public static ILanguage Razor => LanguageRepository.FindById(LanguageId.Razor);

        /// <summary>
        /// Language support for ASP.NET pages (.aspx files).
        /// </summary>
        /// <value>Language support for ASP.NET pages (.aspx files).</value>
        public static ILanguage Aspx
        {
            get { return LanguageRepository.FindById(LanguageId.Aspx); }
        }

        /// <summary>
        /// Language support for ASP.NET C# code-behind files (.aspx.cs files).
        /// </summary>
        /// <value>Language support for ASP.NET C# code-behind files (.aspx.cs files).</value>
        public static ILanguage AspxCs
        {
            get { return LanguageRepository.FindById(LanguageId.AspxCs); }
        }

        /// <summary>
        /// Language support for C#.
        /// </summary>
        /// <value>Language support for C#.</value>
        public static ILanguage CSharp
        {
            get { return LanguageRepository.FindById(LanguageId.CSharp); }
        }

        /// <summary>
        /// Language support for HTML.
        /// </summary>
        /// <value>Language support for HTML.</value>
        public static ILanguage Html
        {
            get { return LanguageRepository.FindById(LanguageId.Html); }
        }

        /// <summary>
        /// Language support for PowerShell
        /// </summary>
        /// <value>Language support for PowerShell.</value>
        public static ILanguage PowerShell
        {
            get { return LanguageRepository.FindById(LanguageId.PowerShell); }
        }

        /// <summary>
        /// Language support for SQL.
        /// </summary>
        /// <value>Language support for SQL.</value>
        public static ILanguage Sql
        {
            get { return LanguageRepository.FindById(LanguageId.Sql); }
        }

        /// <summary>
        /// Language support for XML.
        /// </summary>
        /// <value>Language support for XML.</value>
        public static ILanguage Xml
        {
            get { return LanguageRepository.FindById(LanguageId.Xml); }
        }

        /// <summary>
        /// Language support for F#.
        /// </summary>
        /// <value>Language support for F#.</value>
        public static ILanguage FSharp
        {
            get { return LanguageRepository.FindById(LanguageId.FSharp); }
        }

        /// <summary>
        /// Language support for Markdown.
        /// </summary>
        /// <value>Language support for Markdown.</value>
        public static ILanguage Markdown
        {
            get { return LanguageRepository.FindById(LanguageId.Markdown); }
        }

        /// <summary>
        /// Finds a loaded language by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the language to find.</param>
        /// <returns>An <see cref="ILanguage" /> instance if the specified identifier matches a loaded language; otherwise, null.</returns>
        public static ILanguage FindById(string id)
        {
            return LanguageRepository.FindById(id);
        }

        private static void Load<T>()
            where T : ILanguage, new()
        {
            Load(new T());
        }

        /// <summary>
        /// Loads the specified language.
        /// </summary>
        /// <param name="language">The language to load.</param>
        /// <remarks>
        /// If a language with the same identifier has already been loaded, the existing loaded language will be replaced by the new specified language.
        /// </remarks>
        public static void Load(ILanguage language)
        {
            LanguageRepository.Load(language);
        }
    }
/// <summary>
/// Creates a <see cref="CodeColorizerBase"/>, for creating Syntax Highlighted code.
/// </summary>
/// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
/// <param name="languageParser">The language parser that the <see cref="CodeColorizerBase"/> instance will use for its lifetime.</param>
public abstract class CodeColorizerBase
{
    public CodeColorizerBase(StyleDictionary Styles, ILanguageParser languageParser)
    {
        this.languageParser = languageParser
                              ?? new LanguageParser(new LanguageCompiler(Languages.CompiledLanguages, Languages.CompileLock), Languages.LanguageRepository);

        this.Styles = Styles;
    }

    /// <summary>
    /// Writes the parsed source code to the ouput using the specified style sheet.
    /// </summary>
    /// <param name="parsedSourceCode">The parsed source code to format and write to the output.</param>
    /// <param name="scopes">The captured scopes for the parsed source code.</param>
    protected abstract void Write(string parsedSourceCode, IList<Scope> scopes);

    /// <summary>
    /// The language parser that the <see cref="CodeColorizerBase"/> instance will use for its lifetime.
    /// </summary>
    protected readonly ILanguageParser languageParser;

    /// <summary>
    /// The styles to Apply to the formatted Code.
    /// </summary>
    public readonly StyleDictionary Styles;
}
public interface ILanguageParser
{
    void Parse(string sourceCode,
        ILanguage language,
        Action<string, IList<Scope>> parseHandler);
}
/// <summary>
    /// Creates a <see cref="HtmlClassFormatter"/>, for creating HTML to display Syntax Highlighted code.
    /// </summary>
    public class HtmlClassFormatter : CodeColorizerBase
    {
        /// <summary>
        /// Creates a <see cref="HtmlClassFormatter"/>, for creating HTML to display Syntax Highlighted code, with Styles applied via CSS.
        /// </summary>
        /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
        /// <param name="languageParser">The language parser that the <see cref="HtmlClassFormatter"/> instance will use for its lifetime.</param>
        public HtmlClassFormatter(StyleDictionary Style = null, ILanguageParser languageParser = null) : base(Style, languageParser)
        {
        }

        private TextWriter Writer { get; set; }

        /// <summary>
        /// Creates the HTML Markup, which can be saved to a .html file.
        /// </summary>
        /// <param name="sourceCode">The source code to colorize.</param>
        /// <param name="language">The language to use to colorize the source code.</param>
        /// <returns>Colorised HTML Markup.</returns>
        public string GetHtmlString(string sourceCode, ILanguage language)
        {
            var buffer = new StringBuilder(sourceCode.Length * 2);

            using (TextWriter writer = new StringWriter(buffer))
            {
                Writer = writer;
                WriteHeader(language);

                languageParser.Parse(sourceCode, language, (parsedSourceCode, captures) => Write(parsedSourceCode, captures));

                WriteFooter(language);

                writer.Flush();
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Creates the CSS Markup, which can be saved to a .CSS file. <para/>
        /// This is required for Coloring the Html output. Be sure to reference the File from the HTML, or insert it inline to the Head.
        /// </summary>
        /// <returns></returns>
        public string GetCSSString()
        {
            var str = new StringBuilder();

            var plainText = Styles[ScopeName.PlainText];
            if (!string.IsNullOrWhiteSpace(plainText?.Background)) str.Append($"body{{background-color:{plainText.Background};}}");

            foreach (var style in Styles)
            {
                str.Append($" .{style.ReferenceName}{{");

                if (style.Italic)
                    str.Append("italic");

                if (style.Bold)
                    str.Append("font-bold");

                str.Append("}");
            }

            return str.ToString();
        }

        protected override void Write(string parsedSourceCode, IList<Scope> scopes)
        {
            var styleInsertions = new List<TextInsertion>();

            foreach (Scope scope in scopes)
                GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

            styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

            int offset = 0;

            foreach (TextInsertion styleInsertion in styleInsertions)
            {
                Writer.Write(WebUtility.HtmlEncode(parsedSourceCode.Substring(offset, styleInsertion.Index - offset)));
                if (string.IsNullOrEmpty(styleInsertion.Text))
                    BuildSpanForCapturedStyle(styleInsertion.Scope);
                else
                    Writer.Write(styleInsertion.Text);
                offset = styleInsertion.Index;
            }

            Writer.Write(WebUtility.HtmlEncode(parsedSourceCode.Substring(offset)));
        }

        private void WriteFooter(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            Writer.WriteLine();
            WriteHeaderPreEnd();
            WriteHeaderDivEnd();
        }

        private void WriteHeader(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            WriteHeaderDivStart(language);
            WriteHeaderPreStart();
            Writer.WriteLine();
        }

        private static void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
        {
            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index,
                Scope = scope
            });

            foreach (Scope childScope in scope.Children)
                GetStyleInsertionsForCapturedStyle(childScope, styleInsertions);

            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index + scope.Length,
                Text = "</span>"
            });
        }

        private void BuildSpanForCapturedStyle(Scope scope)
        {
            string cssClassName = "";

            if (Styles.Contains(scope.Name))
            {
                Style style = Styles[scope.Name];

                cssClassName = style.ReferenceName;
            }

            WriteElementStart("span", cssClassName);
        }

        private void WriteHeaderDivEnd()
        {
            WriteElementEnd("div");
        }

        private void WriteElementEnd(string elementName)
        {
            Writer.Write("</{0}>", elementName);
        }

        private void WriteHeaderPreEnd()
        {
            WriteElementEnd("pre");
        }

        private void WriteHeaderPreStart()
        {
            WriteElementStart("pre");
        }

        private void WriteHeaderDivStart(ILanguage language)
        {
            WriteElementStart("div", language.CssClassName);
        }

        private void WriteElementStart(string elementName)
        {
            WriteElementStart(elementName, "");
        }

        private void WriteElementStart(string elementName, string cssClassName)
        {
            Writer.Write("<{0}", elementName);
            if (!String.IsNullOrEmpty(cssClassName))
            {
                Writer.Write(" class=\"{0}\"", cssClassName);
            }
            Writer.Write(">");
        }
    }
