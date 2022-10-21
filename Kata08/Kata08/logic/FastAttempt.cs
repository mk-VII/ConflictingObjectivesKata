using Kata08.logic.interfaces;
using Kata08.model;
using Kata08.repository.interfaces;

namespace Kata08.logic;

public class FastAttempt : IAttempt
{
    private readonly IWordListRepository _repository;
    public int MaxWordLength { get; init; }

    public FastAttempt(IWordListRepository repository, int max = 6)
    {
        _repository = repository;
        MaxWordLength = max;
    }
    
    public async Task<IEnumerable<WordWithSubWords>> GetWordsWithSubWords()
    {
        var wordList = (await _repository.GetWordList()).ToArray();

        // var stuff = wordList.Select(word =>
        //     {
        //         var possibleFirstSubWords = wordList
        //             .Where(sub => sub.Length < word.Length)
        //             .Where(word.StartsWith);
        //
        //         foreach (var possibleFirstSubWord in possibleFirstSubWords)
        //         {
        //             var stuff = wordList
        //                 .Where(x => word.Length - possibleFirstSubWord.Length == x.Length)
        //                 .Where(word.EndsWith);
        //         }
        //     }
        // );
        //
        // return stuff;

        return null;
    }
}