using Kata08.model;

namespace Kata08.logic.interfaces;

public interface IAttempt
{
    int MaxWordLength { get; init; }

    Task<IEnumerable<WordWithSubWords>> GetWordsWithSubWords();
}