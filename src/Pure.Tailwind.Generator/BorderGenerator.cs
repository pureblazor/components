using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Pure.Tailwind.Generator;

//[Generator]
public class BorderGenerator : ISourceGenerator
{
    private const string attributeText = @"
using System;
namespace Pure.Tailwind {
[AttributeUsage(AttributeTargets.Field)]
public class BorderAttribute : Attribute
{
    public BorderAttribute(string color){ Color = color; }
public BorderAttribute(string color, int shade){ Color = color; Shade=shade;}
#nullable enable
    public string? Color { get; set; }
#nullable disable
    public int Shade { get; set; }
}}";
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization((i) => i.AddSource("BorderAttribute.g.cs", attributeText));
        context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
    }
    public void Execute(GeneratorExecutionContext context)
    {
        if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
        {
            return;
        }

        // get the added attribute, and INotifyPropertyChanged
        INamedTypeSymbol attributeSymbol = context.Compilation.GetTypeByMetadataName("Pure.Tailwind.BorderAttribute");
        //INamedTypeSymbol notifySymbol = context.Compilation.GetTypeByMetadataName("System.ComponentModel.INotifyPropertyChanged");

        // group the fields by class, and generate the source
        foreach (IGrouping<INamedTypeSymbol, IFieldSymbol> group in receiver.Fields.GroupBy<IFieldSymbol, INamedTypeSymbol>(f => f.ContainingType, SymbolEqualityComparer.Default))
        {
            string classSource = ProcessClass(group.Key, group.ToList(), attributeSymbol, context);
            context.AddSource($"{group.Key.Name}_tailwindBorder.g.cs", SourceText.From(classSource, Encoding.UTF8));
        }
    }

    private string ProcessClass(INamedTypeSymbol classSymbol, List<IFieldSymbol> fields, ISymbol attributeSymbol, GeneratorExecutionContext context)
    {
        if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
        {
            return null; //TODO: issue a diagnostic that it must be top level
        }

        string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

        // begin building the generated source
        StringBuilder source = new StringBuilder($@"
namespace {namespaceName}
{{
    public partial class {classSymbol.Name}
    {{
");

        // if the class doesn't implement INotifyPropertyChanged already, add it
        //if (!classSymbol.Interfaces.Contains(notifySymbol, SymbolEqualityComparer.Default))
        //{
        //    source.Append("public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;");
        //}

        // create properties for each field 
        foreach (IFieldSymbol fieldSymbol in fields)
        {
            ProcessField(source, fieldSymbol, attributeSymbol);
        }

        source.Append("} }");
        return source.ToString();
    }

    private void ProcessField(StringBuilder source, IFieldSymbol fieldSymbol, ISymbol attributeSymbol)
    {
        // get the name and type of the field
        string fieldName = fieldSymbol.Name;
        ITypeSymbol fieldType = fieldSymbol.Type;

        // get the AutoNotify attribute from the field, and any associated data
        var attributes = fieldSymbol.GetAttributes();
        AttributeData attributeData = attributes.Single(ad => ad.AttributeClass.Equals(attributeSymbol, SymbolEqualityComparer.Default));
        TypedConstant overridenNameOpt = attributeData.NamedArguments.SingleOrDefault(kvp => kvp.Key == "PropertyName").Value;
        
        string propertyName = chooseName(fieldName, overridenNameOpt);
        if (propertyName.Length == 0 || propertyName == fieldName)
        {
            //TODO: issue a diagnostic that we can't process this field
            return;
        }

        foreach (var arg in attributeData.NamedArguments)
        {
            Console.WriteLine(arg.Key, arg.Value);
        }

        source.Append($@"
public {fieldType} {propertyName} 
{{
    get 
    {{
        return this.{fieldName} + "" test"";
    }}
}}

");

        string chooseName(string fieldName, TypedConstant overridenNameOpt)
        {
            if (!overridenNameOpt.IsNull)
            {
                return overridenNameOpt.Value.ToString();
            }

            fieldName = fieldName.TrimStart('_');
            if (fieldName.Length == 0)
                return string.Empty;

            if (fieldName.Length == 1)
                return fieldName.ToUpper();

            return fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);
        }

    }

    class SyntaxReceiver : ISyntaxContextReceiver
    {
        public List<IFieldSymbol> Fields { get; } = new List<IFieldSymbol>();
        public List<(string className, string element, string color)> TemplateInfo = [];

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            //if (context.Node is syntax)
            if (context.Node is AttributeSyntax attrib)
            {
                var typeInfo = context.SemanticModel.GetTypeInfo(attrib);
                if (typeInfo.Type?.Name.ToString() == "BorderAttribute")
                {
                    //string element = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[0].Expression).ToString();
                    //string color = context.SemanticModel.GetConstantValue(attrib.ArgumentList.Arguments[1].Expression).ToString();
                    //var className = (attrib.Parent?.Parent as MemberDeclarationSyntax)??.Identifier.Text ?? throw new InvalidOperationException("Can't find class name for attribute");
                    //context.SemanticModel.GetDeclaredSymbol(attrib.Parent.Parent);
                    //TemplateInfo.Add((className, element, color));
                }
            }
        }
    }
}

//class SyntaxReceiver : ISyntaxContextReceiver
//{
//    public List<IFieldSymbol> Fields { get; } = new List<IFieldSymbol>();

//    /// <summary>
//    /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
//    /// </summary>
//    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
//    {
//        // any field with at least one attribute is a candidate for property generation
//        if (context.Node is FieldDeclarationSyntax fieldDeclarationSyntax
//            && fieldDeclarationSyntax.AttributeLists.Count > 0)
//        {
//            foreach (VariableDeclaratorSyntax variable in fieldDeclarationSyntax.Declaration.Variables)
//            {
//                // Get the symbol being declared by the field, and keep it if its annotated
//                IFieldSymbol fieldSymbol = context.SemanticModel.GetDeclaredSymbol(variable) as IFieldSymbol;
//                var attributes = fieldSymbol.GetAttributes();
//                if (attributes.Any(ad => ad.AttributeClass.ToDisplayString() == "Pure.Tailwind.BorderAttribute"))
//                {
//                    Fields.Add(fieldSymbol);
//                }
//            }
//        }
//    }
//}
