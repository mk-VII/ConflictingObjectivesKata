using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text;
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

    public async Task<IEnumerable<Word>> GetWordsWithSubWords()
    {
        var wordList = await _repository.GetWordList();

        var possibleWords = new List<byte[]>();
        var possibleSubWords = new HashSet<byte[]>(new ByteArrayComparer());
        
        foreach (var word in wordList)
        {
            if (word.Length == MaxWordLength)
            {
                possibleWords.Add(Encoding.Unicode.GetBytes(word));
            }
            if (word.Length < MaxWordLength)
            {
                possibleSubWords.Add(Encoding.Unicode.GetBytes(word));
            }
        }

        var resultBag = new ConcurrentBag<(string, string)>();

        Parallel.ForEach(possibleWords, possibleWord =>
        {
            var prefixes = possibleSubWords
                .Where(pre => StartsWith(possibleWord, pre))
                .ToArray();

            foreach (var prefix in prefixes)
            {
                var suffixLength = 12 - prefix.Length;
                var possibleSuffix = new byte[suffixLength];

                Array.Copy(possibleWord,
                    prefix.Length,
                    possibleSuffix,
                    0,
                    suffixLength);

                if (possibleSubWords.Contains(possibleSuffix))
                {
                    resultBag.Add((
                        Encoding.Unicode.GetString(prefix).ToLower(),
                        Encoding.Unicode.GetString(possibleSuffix).ToLower()
                    ));
                }
            }
        });

        return resultBag
            .OrderBy(res => res.Item1)
            .Select(res => new Word(new[] { res.Item1, res.Item2 }));
    }

    private static bool StartsWith(IReadOnlyList<byte> value, IReadOnlyList<byte> prefix)
    {
        for (var i = 0; i < prefix.Count; i++)
        {
            if (prefix[i] != value[i])
                return false;
        }

        return true;
    }

    private class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[]? firstByteArray, byte[]? secondByteArray)
        {
            if (firstByteArray == null || secondByteArray == null
                                       || firstByteArray.Length != secondByteArray.Length)
            {
                return false;
            }

            for (var i = 0; i < firstByteArray.Length; i++)
            {
                if (firstByteArray[i] != secondByteArray[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(byte[] bytes) =>
            Encoding.Unicode.GetString(bytes).GetHashCode();
    }
}