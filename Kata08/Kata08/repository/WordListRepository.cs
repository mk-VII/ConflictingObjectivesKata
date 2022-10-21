using Kata08.repository.interfaces;

namespace Kata08.repository;

public sealed class WordListRepository : IWordListRepository
{
    public async Task<IEnumerable<string>> GetWordList()
    {
        return await File.ReadAllLinesAsync(@"..\..\..\..\Kata08\data\wordlist.txt");
    }
}