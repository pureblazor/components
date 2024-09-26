using System.Collections.ObjectModel;

namespace PureBlazor.com.Client.Editor;

public partial class TailwindStyleDictionary : KeyedCollection<string, Style>
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
    /// <summary>
    /// A theme with Light Colors.
    /// </summary>
    public static StyleDictionary DefaultLight
    {
        get
        {
            return new StyleDictionary
            {
                new(ScopeName.PlainText)
                {
                    // Foreground = Black,
                    // Background = White,
                    ReferenceName = "plainText"
                },
                new(ScopeName.HtmlServerSideScript)
                {
                    // Background = Yellow,
                    ReferenceName = "htmlServerSideScript"
                },
                new(ScopeName.HtmlComment)
                {
                    // Foreground = Green,
                    ReferenceName = "htmlComment"
                },
                new(ScopeName.HtmlTagDelimiter)
                {
                    // Foreground = Blue,
                    ReferenceName = "text-blue-700"
                },
                new(ScopeName.HtmlElementName)
                {
                    // Foreground = DullRed,
                    ReferenceName = "htmlElementName"
                },
                new(ScopeName.HtmlAttributeName)
                {
                    // Foreground = Red,
                    ReferenceName = "htmlAttributeName"
                },
                new(ScopeName.HtmlAttributeValue)
                {
                    // Foreground = Blue,
                    ReferenceName = "htmlAttributeValue"
                },
                new(ScopeName.HtmlOperator)
                {
                    // Foreground = Blue,
                    ReferenceName = "htmlOperator"
                },
                new(ScopeName.Comment)
                {
                    // Foreground = Green,
                    ReferenceName = "comment"
                },
                new(ScopeName.XmlDocTag)
                {
                    // Foreground = Gray,
                    ReferenceName = "xmlDocTag"
                },
                new(ScopeName.XmlDocComment)
                {
                    // Foreground = Green,
                    ReferenceName = "xmlDocComment"
                },
                new(ScopeName.String)
                {
                    // Foreground = DullRed,
                    ReferenceName = "text-amber-800 string"
                },
                new(ScopeName.StringCSharpVerbatim)
                {
                    // Foreground = DullRed,
                    ReferenceName = "stringCSharpVerbatim"
                },
                new(ScopeName.Keyword)
                {
                    // Foreground = Blue,
                    ReferenceName = "text-blue-700 keyword"
                },
                new(ScopeName.PreprocessorKeyword)
                {
                    // Foreground = Blue,
                    ReferenceName = "preprocessorKeyword"
                },
                new(ScopeName.HtmlEntity)
                {
                    // Foreground = Red,
                    ReferenceName = "htmlEntity"
                },
                new(ScopeName.JsonKey)
                {
                    // Foreground = DarkOrange,
                    ReferenceName = "jsonKey"
                },
                new(ScopeName.JsonString)
                {
                    // Foreground = DarkCyan,
                    ReferenceName = "jsonString"
                },
                new(ScopeName.JsonNumber)
                {
                    // Foreground = BrightGreen,
                    ReferenceName = "jsonNumber"
                },
                new(ScopeName.JsonConst)
                {
                    // Foreground = BrightPurple,
                    ReferenceName = "jsonConst"
                },
                new(ScopeName.XmlAttribute)
                {
                    // Foreground = Red,
                    ReferenceName = "xmlAttribute"
                },
                new(ScopeName.XmlAttributeQuotes)
                {
                    // Foreground = Black,
                    ReferenceName = "xmlAttributeQuotes"
                },
                new(ScopeName.XmlAttributeValue)
                {
                    // Foreground = Blue,
                    ReferenceName = "xmlAttributeValue"
                },
                new(ScopeName.XmlCDataSection)
                {
                    // Foreground = Gray,
                    ReferenceName = "xmlCDataSection"
                },
                new(ScopeName.XmlComment)
                {
                    // Foreground = Green,
                    ReferenceName = "xmlComment"
                },
                new(ScopeName.XmlDelimiter)
                {
                    // Foreground = Blue,
                    ReferenceName = "xmlDelimiter"
                },
                new(ScopeName.XmlName)
                {
                    // Foreground = DullRed,
                    ReferenceName = "xmlName"
                },
                new(ScopeName.ClassName)
                {
                    // Foreground = MediumTurqoise,
                    ReferenceName = "className"
                },
                new(ScopeName.CssSelector)
                {
                    // Foreground = DullRed,
                    ReferenceName = "cssSelector"
                },
                new(ScopeName.CssPropertyName)
                {
                    // Foreground = Red,
                    ReferenceName = "cssPropertyName"
                },
                new(ScopeName.CssPropertyValue)
                {
                    // Foreground = Blue,
                    ReferenceName = "cssPropertyValue"
                },
                new(ScopeName.SqlSystemFunction)
                {
                    // Foreground = Magenta,
                    ReferenceName = "sqlSystemFunction"
                },
                new(ScopeName.PowerShellAttribute)
                {
                    // Foreground = PowderBlue,
                    ReferenceName = "powershellAttribute"
                },
                new(ScopeName.PowerShellOperator)
                {
                    // Foreground = Gray,
                    ReferenceName = "powershellOperator"
                },
                new(ScopeName.PowerShellType)
                {
                    // Foreground = Teal,
                    ReferenceName = "powershellType"
                },
                new(ScopeName.PowerShellVariable)
                {
                    // Foreground = OrangeRed,
                    ReferenceName = "powershellVariable"
                },
                new(ScopeName.PowerShellCommand)
                {
                    // Foreground = Navy,
                    ReferenceName = "powershellCommand"
                },
                new(ScopeName.PowerShellParameter)
                {
                    // Foreground = Gray,
                    ReferenceName = "powershellParameter"
                },

                new(ScopeName.Type)
                {
                    // Foreground = Teal,
                    ReferenceName = "text-sky-700 type"
                },
                new(ScopeName.TypeVariable)
                {
                    // Foreground = Teal,
                    Italic = true,
                    ReferenceName = "typeVariable"
                },
                new(ScopeName.NameSpace)
                {
                    // Foreground = Navy,
                    ReferenceName = "namespace"
                },
                new(ScopeName.Constructor)
                {
                    // Foreground = Purple,
                    ReferenceName = "constructor"
                },
                new(ScopeName.Predefined)
                {
                    // Foreground = Navy,
                    ReferenceName = "predefined"
                },
                new(ScopeName.PseudoKeyword)
                {
                    // Foreground = Navy,
                    ReferenceName = "pseudoKeyword"
                },
                new(ScopeName.StringEscape)
                {
                    // Foreground = Gray,
                    ReferenceName = "stringEscape"
                },
                new(ScopeName.ControlKeyword)
                {
                    // Foreground = Blue,
                    ReferenceName = "controlKeyword"
                },
                new(ScopeName.Number)
                {
                    ReferenceName = "number"
                },
                new(ScopeName.Operator)
                {
                    ReferenceName = "operator"
                },
                new(ScopeName.Delimiter)
                {
                    ReferenceName = "delimiter"
                },

                new(ScopeName.MarkdownHeader)
                {
                    // Foreground = Blue,
                    Bold = true,
                    ReferenceName = "markdownHeader"
                },
                new(ScopeName.MarkdownCode)
                {
                    // Foreground = Teal,
                    ReferenceName = "markdownCode"
                },
                new(ScopeName.MarkdownListItem)
                {
                    Bold = true,
                    ReferenceName = "markdownListItem"
                },
                new(ScopeName.MarkdownEmph)
                {
                    Italic = true,
                    ReferenceName = "italic"
                },
                new(ScopeName.MarkdownBold)
                {
                    Bold = true,
                    ReferenceName = "bold"
                },

                new(ScopeName.BuiltinFunction)
                {
                    // Foreground = OliveDrab,
                    Bold = true,
                    ReferenceName = "builtinFunction"
                },
                new(ScopeName.BuiltinValue)
                {
                    // Foreground = DarkOliveGreen,
                    Bold = true,
                    ReferenceName = "builtinValue"
                },
                new(ScopeName.Attribute)
                {
                    // Foreground = DarkCyan,
                    Italic = true,
                    ReferenceName = "attribute"
                },
                new(ScopeName.SpecialCharacter)
                {
                    ReferenceName = "specialChar"
                },
                new(ScopeName.MethodName)
                {
                    ReferenceName = "methodName"
                },
                new(ScopeName.MethodCall)
                {
                    ReferenceName = "methodCall"
                },
                new(ScopeName.MethodParameter)
                {
                    ReferenceName = "text-sky-700 methodParameter"
                },
            };
        }
    }
}
