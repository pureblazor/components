using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Pure.Tailwind.Generator;

[Generator]
public class TailwindGenerator : ISourceGenerator
{
    private const string TailwindColorAttributeSource = """
                                                        using System;
                                                        namespace Pure.Tailwind;
                                                        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
                                                        public class TailwindColorAttribute : Attribute
                                                        {
                                                            public string Element { get; set; }
                                                            public string Color { get; set; }
                                                            public TailwindColorAttribute(string element, string color)
                                                            {
                                                                Element = element;
                                                                Color = color;
                                                            }
                                                        }
                                                        """;
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization(c =>
        {
            c.AddSource("TailwindColorAttribute.g.cs", TailwindColorAttributeSource);
        });
        
        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        SyntaxReceiver rx = (SyntaxReceiver)context.SyntaxContextReceiver!;
        foreach ((string className, string element, string color) in rx.TemplateInfo)
        {
            string source = SourceFileFromTailwindPath(className, element, color);
            context.AddSource($"Tailwind{element}{color}.g.cs", source);
        }
    }

    static string SourceFileFromTailwindPath(string className, string element, string color)
    {
        List<int> shades = [50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950];
        List<string> elements = ["text", "bg", "border", "decoration", "divide", "outline", "ring", "shadow", "accent", "caret"];

        var cssColorName = color.ToLower();
        StringBuilder sb = new StringBuilder();
        sb.Append($$"""
                    namespace Pure.Blazor.Components.Utilities {
                    
                        public partial class {{className}} {

                    """);
            var titleCaseColor = string.Concat(color[0].ToString().ToUpper(), color.AsSpan(1).ToString());
            foreach (var shade in shades)
            {
                sb.AppendLine($"""public const string {titleCaseColor}{shade} = "{element}-{cssColorName}-{shade}";""");
            }
        

        sb.AppendLine($"""public const string {titleCaseColor} = "{element}-{color}-600";""");

        sb.Append($$"""
                        }
                    }
                    """);
        return sb.ToString();
    }

    class SyntaxReceiver : ISyntaxContextReceiver
    {
        public List<(string className, string element, string color)> TemplateInfo = [];

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is AttributeSyntax attrib)
            {
                var typeInfo = context.SemanticModel.GetTypeInfo(attrib);
                if (typeInfo.Type?.Name.ToString() == "TailwindAttribute")
                {
                    string element = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[0].Expression).ToString();
                    string color = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[1].Expression).ToString();
                    var className = (attrib.Parent?.Parent as ClassDeclarationSyntax)?.Identifier.Text ?? throw new InvalidOperationException("Can't find class name for attribute");
                    TemplateInfo.Add((className, element, color));
                }
            }
        }
    }
}