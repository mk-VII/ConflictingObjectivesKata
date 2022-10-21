namespace Kata08.logic.helper;

public static class WordListStandardiser
{
    public static IEnumerable<string> Standardise(IEnumerable<string> wordList) => 
        wordList.Select(word => word.ToLower()).Distinct();
}