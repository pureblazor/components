using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace PureBlazor.com.Client.Shared;

// src: https://learn.microsoft.com/en-us/archive/msdn-magazine/2019/october/csharp-accessing-xml-documentation-via-reflection
public static class AssemblyExtensions
{
    internal static HashSet<Assembly> loadedAssemblies = new();

    internal static Dictionary<string, string> loadedXmlDocumentation = new();

    public static string? GetDirectoryPath(this Assembly assembly)
    {
        var codeBase = assembly.Location;
        var uri = new UriBuilder(codeBase);
        var path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
    }

    internal static void LoadXmlDocumentation(Assembly assembly)
    {
        if (loadedAssemblies.Contains(assembly))
        {
            return; // Already loaded
        }

        var directoryPath = assembly.GetDirectoryPath();
        if (directoryPath is null)
        {
            return;
        }

        var xmlFilePath = Path.Combine(directoryPath, assembly.GetName().Name + ".xml");
        if (File.Exists(xmlFilePath))
        {
            LoadXmlDocumentation(File.ReadAllText(xmlFilePath));
            loadedAssemblies.Add(assembly);
        }
    }

    public static void LoadXmlDocumentation(string xmlDocumentation)
    {
        using (var xmlReader = XmlReader.Create(new StringReader(xmlDocumentation)))
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    var raw_name = xmlReader["name"];
                    if (raw_name is null)
                    {
                        continue;
                    }

                    loadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
                }
            }
        }
    }

    public static string? GetDocumentation(this MemberInfo memberInfo)
    {
        try
        {
            //if (memberInfo.MemberType.HasFlag(MemberTypes.Field))
            //{
            //    return ((FieldInfo) memberInfo).GetDocumentation();
            //}
            //if (memberInfo.MemberType.HasFlag(MemberTypes.Property))
            //{
            //    return ((PropertyInfo) memberInfo).GetDocumentation();
            //}
            if (memberInfo.MemberType.HasFlag(MemberTypes.Event))
            {
                return ((EventInfo)memberInfo).GetDocumentation();
            }

            if (memberInfo.MemberType.HasFlag(MemberTypes.Constructor))
            {
                return ((ConstructorInfo)memberInfo).GetDocumentation();
            }

            if (memberInfo.MemberType.HasFlag(MemberTypes.Method))
            {
                return ((MethodInfo)memberInfo).GetDocumentation();
            }

            if (memberInfo.MemberType.HasFlag(MemberTypes.TypeInfo) ||
                memberInfo.MemberType.HasFlag(MemberTypes.NestedType))
            {
                return ((TypeInfo)memberInfo).GetDocumentation();
            }

            return null;
        }
        catch (Exception)
        {
            return "";
        }
    }

    public static string? GetDocumentation(this ParameterInfo parameterInfo)
    {
        var memberDocumentation = parameterInfo.Member.GetDocumentation();
        if (memberDocumentation != null)
        {
            var regexPattern =
                Regex.Escape(@"<param name=" + "\"" + parameterInfo.Name + "\"" + @">") +
                ".*?" +
                Regex.Escape(@"</param>");
            var match = Regex.Match(memberDocumentation, regexPattern);
            if (match.Success)
            {
                return match.Value;
            }
        }

        return null;
    }
}
