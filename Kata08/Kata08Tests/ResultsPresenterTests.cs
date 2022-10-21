using Kata08.logic.interfaces;
using Kata08.repository;

namespace Kata08;

[TestClass]
public class ResultsPresenterTests
{
    private ResultsPresenter _resultsPresenter;
    
    [TestMethod]
    public async Task GetResults_ReadableAttempt()
    {
        _resultsPresenter = new ResultsPresenter(new ReadableAttempt(new WordListRepository()));

        var results = (await _resultsPresenter.GetResults()).ToArray();
        
        Assert.AreEqual(40010, results.Length);
        Assert.AreEqual(@"ac + th's => acth's", results.First());
        Assert.AreEqual(@"étude + s => études", results.Last());
        
        CollectionAssert.Contains(results, "al + bums => albums");
        CollectionAssert.Contains(results, "bar + ely => barely");
        CollectionAssert.Contains(results, "be + foul => befoul");
        CollectionAssert.Contains(results, "con + vex => convex");
        CollectionAssert.Contains(results, "here + by => hereby");
        CollectionAssert.Contains(results, "jig + saw => jigsaw");
        CollectionAssert.Contains(results, "tail + or => tailor");
        CollectionAssert.Contains(results, "we + aver => weaver");
    }
}