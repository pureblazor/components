namespace Pure.Blazor.Components.Primitives;

public interface IPureTheme
{
    public ButtonDefaults ButtonDefaults { get; set; }
    public IStylePrioritizer StylePrioritizer { get; set; }
    public Dictionary<string, ComponentStyle> Styles { get; set; }

    public ComponentStyle GetStyle(Type type)
    {
        return GetStyleByName(type.Name);
    }

    public ComponentStyle GetStyleByName(string name)
    {
        // TODO: decide if we want this to be an exceptional event
        return Styles.GetValueOrDefault(name) ?? new ComponentStyle("", null, null, null);
    }
}
