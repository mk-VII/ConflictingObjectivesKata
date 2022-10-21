namespace Kata08.model;

public class WordWithSubWords
{
    private string Word { get; }
    private string Prefix { get; }
    private string Suffix { get; }
    
    public WordWithSubWords(string word, string prefix, string suffix)
    {
        Word = word;
        Prefix = prefix;
        Suffix = suffix;
    }

    public override string ToString()
    {
        return $"{Prefix} + {Suffix} => {Word}";
    }
}