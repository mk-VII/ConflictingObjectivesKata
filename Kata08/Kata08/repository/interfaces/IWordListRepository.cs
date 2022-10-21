namespace Kata08.repository.interfaces;

public interface IWordListRepository
{
    Task<IEnumerable<string>> GetWordList();
}