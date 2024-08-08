namespace Pure.Blazor.Components.Primitives;

public record PureTheme
{
    public ButtonDefaults ButtonDefaults { get; set; } = new();
    public IStylePrioritizer? StylePrioritizer { get; set; }
    public Dictionary<string, ComponentStyle> Styles { get; set; } = new();

    public ComponentStyle GetStyle(Type type)
    {
        return GetStyleByName(type.Name);
    }

    public ComponentStyle GetStyleByName(string name)
    {
        // TODO: decide if we want this to be an exceptional event
        return Styles.GetValueOrDefault(name) ?? new ComponentStyle("");
    }

    /// <summary>
    /// Merges the styles into the current theme, overwriting any existing styles.
    /// </summary>
    /// <param name="styles"></param>
    public void Merge(Dictionary<string, ComponentStyle> styles)
    {
        Styles = Styles.MergeLeft(styles);
    }
}

// https://stackoverflow.com/a/2679857/783284
internal static class DictionaryExtensions
{
    // Works in C#3/VS2008:
    // Returns a new dictionary of this ... others merged leftward.
    // Keeps the type of 'this', which must be default-instantiable.
    // Example:
    //   result = map.MergeLeft(other1, other2, ...)
    public static T MergeLeft<T,K,V>(this T me, params IDictionary<K,V>[] others)
        where T : IDictionary<K,V>, new()
    {
        T newMap = new T();
        foreach (IDictionary<K,V> src in
                 (new List<IDictionary<K,V>> { me }).Concat(others)) {
            // ^-- echk. Not quite there type-system.
            foreach (KeyValuePair<K,V> p in src) {
                newMap[p.Key] = p.Value;
            }
        }
        return newMap;
    }

}
