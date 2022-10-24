using Kata08.model.interfaces;

namespace Kata08.model.@base;

public class IntegerSubComponents : ISubComponents<int>
{
    public int Value { get; }
    public IEnumerable<int> SubComponents { get; }

    public string Separator => " + ";

    protected IntegerSubComponents(IEnumerable<int> subComponents)
    {
        var components = subComponents.ToArray();
        Value = components.Sum();
        SubComponents = components;
    }

    public override string ToString() => SubComponents.Any()
        ? $"{string.Join(Separator, SubComponents)} => {Value}"
        : string.Empty;
}