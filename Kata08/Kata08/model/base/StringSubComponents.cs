using Kata08.model.interfaces;

namespace Kata08.model.@base;

public class StringSubComponents : ISubComponents<string>
{
    public string Value { get; }
    public IEnumerable<string> SubComponents { get; }
    
    public string Separator => " + ";

    protected StringSubComponents(IEnumerable<string> subComponents)
    {
        var components = subComponents.ToArray();
        Value = string.Join("", components);
        SubComponents = components;
    }

    public override string ToString() => SubComponents.Any()
        ? $"{string.Join(Separator, SubComponents)} => {Value}"
        : string.Empty;
}