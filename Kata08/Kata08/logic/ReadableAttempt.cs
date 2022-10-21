using Kata08.logic.helper;
using Kata08.logic.interfaces;
using Kata08.model;
using Kata08.repository.interfaces;

namespace Kata08;

public class ReadableAttempt : IAttempt
{
    private readonly IWordListRepository _repository;
    public int MaxWordLength { get; init; }

    public ReadableAttempt(IWordListRepository repository, int max = 6)
    {
        _repository = repository;
        MaxWordLength = max;
    }

    public async Task<IEnumerable<WordWithSubWords>> GetWordsWithSubWords()
    {
        var wordList = WordListStandardiser
            .Standardise(await _repository.GetWordList())
            .ToArray();

        var possibleWords = wordList
            .Where(word => word.Length == MaxWordLength)
            .ToArray();
        var possibleSubWords = wordList
            .Where(word => word.Length < MaxWordLength)
            .ToArray();

        var wordsWithSubWords = new List<WordWithSubWords>();

        foreach (var wholeWord in possibleWords)
        {
            var prefixes = possibleSubWords.Where(wholeWord.StartsWith);

            foreach (var prefix in prefixes)
            {
                var neededSuffix = wholeWord[prefix.Length..];

                if (possibleSubWords.Contains(neededSuffix))
                {
                    wordsWithSubWords.Add(new WordWithSubWords(wholeWord, prefix, neededSuffix));
                }
            }
        }

        return wordsWithSubWords;
    }
}