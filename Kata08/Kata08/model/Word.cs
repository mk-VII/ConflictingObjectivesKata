using Kata08.model.@base;
using Kata08.model.interfaces;

namespace Kata08.model;

public class Word : StringSubComponents
{
    public Word(IEnumerable<string> subComponents) : base(subComponents)
    {
    }
}