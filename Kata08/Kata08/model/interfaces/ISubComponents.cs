namespace Kata08.model.interfaces;

public interface ISubComponents<TComponent>
{
    TComponent Value { get; }
    IEnumerable<TComponent> SubComponents { get; }
    
    string Separator { get; }
}