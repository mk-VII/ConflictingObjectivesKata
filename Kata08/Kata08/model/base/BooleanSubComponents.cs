using Kata08.model.interfaces;

namespace Kata08.model.@base;

public class BooleanSubComponents : ISubComponents<bool>
{
    public bool Value { get; }
    public IEnumerable<bool> SubComponents { get; }
    
    public string Separator => " && ";

    protected BooleanSubComponents(IEnumerable<bool> subComponents)
    {
        var components = subComponents.ToArray();
        Value = components.All(boolean => boolean);
        SubComponents = components;
    }

    public override string ToString() => SubComponents.Any()
        ? $"{string.Join(Separator, SubComponents)} => {Value}"
        : string.Empty;
}