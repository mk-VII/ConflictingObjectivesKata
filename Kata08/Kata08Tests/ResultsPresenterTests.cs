using System.Diagnostics;
using Kata08.helper;
using Kata08.logic;
using Kata08.logic.interfaces;
using Kata08.repository;

namespace Kata08;

[TestClass]
public class ResultsPresenterTests
{
    private ResultsPresenter _resultsPresenter;

    private void AssertResultsCollection(string[] results)
    {
        CollectionAssert.Contains(results, "al + bums => albums");
        CollectionAssert.Contains(results, "bar + ely => barely");
        CollectionAssert.Contains(results, "be + foul => befoul");
        CollectionAssert.Contains(results, "con + vex => convex");
        CollectionAssert.Contains(results, "here + by => hereby");
        CollectionAssert.Contains(results, "jig + saw => jigsaw");
        CollectionAssert.Contains(results, "tail + or => tailor");
        CollectionAssert.Contains(results, "we + aver => weaver");
    }

    [TestMethod]
    public async Task GetResults_ReadableAttempt()
    {
        _resultsPresenter = new ResultsPresenter(new ReadableAttempt(new WordListRepository()));

        var (elapsedSeconds, methodResults) =
            await new MethodTimer<IEnumerable<string>>(_resultsPresenter.GetResults).CallTimedMethod();
        var results = methodResults.ToArray();

        Assert.IsTrue(elapsedSeconds is >= 24 and <= 26);

        Assert.AreEqual(40010, results.Length);
        Assert.AreEqual(@"ac + th's => acth's", results.First());
        Assert.AreEqual(@"étude + s => études", results.Last());

        AssertResultsCollection(results);
    }

    [TestMethod]
    public async Task GetResults_FastAttempt()
    {
        _resultsPresenter = new ResultsPresenter(new FastAttempt(new WordListRepository()));

        var (elapsedSeconds, methodResults) =
            await new MethodTimer<IEnumerable<string>>(_resultsPresenter.GetResults).CallTimedMethod();
        var results = methodResults.ToArray();
        
        Assert.IsTrue(elapsedSeconds is >= 5 and <= 7);

        Assert.AreEqual(30599, results.Length);
        Assert.AreEqual(@"act + h's => acth's", results.First());
        Assert.AreEqual(@"étude + s => études", results.Last());

        AssertResultsCollection(results);
    }
}