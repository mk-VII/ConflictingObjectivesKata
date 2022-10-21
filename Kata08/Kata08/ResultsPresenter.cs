using Kata08.logic.interfaces;

namespace Kata08;

public class ResultsPresenter
{
    private IAttempt _resultsGetter;

    public ResultsPresenter(IAttempt resultsGetter)
    {
        _resultsGetter = resultsGetter;
    }

    public async Task<IEnumerable<string>> GetResults()
    {
        var results = (await _resultsGetter.GetWordsWithSubWords()).ToArray();

        return results.Select(word => word.ToString());
    }
}