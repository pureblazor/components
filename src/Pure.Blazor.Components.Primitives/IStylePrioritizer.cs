namespace Pure.Blazor.Components.Primitives;

public interface IStylePrioritizer
{
    public string PrioritizeStyles(string style1, string style2);
}