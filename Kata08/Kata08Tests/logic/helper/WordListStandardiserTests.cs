namespace Kata08.logic.helper;

[TestClass]
public class WordListStandardiserTests
{
    [TestMethod]
    public void TestCanStandardise_DuplicateWords()
    {
        var wordList = new[] { "land", "land" };

        var standardisedWordList = WordListStandardiser
            .Standardise(wordList)
            .ToArray();
        
        Assert.AreEqual(1, standardisedWordList.Length);
        Assert.AreEqual("land", standardisedWordList[0]);
    }
    
    [TestMethod]
    public void TestCanStandardise_MixedCaseWords()
    {
        var wordList = new[] { "LAND", "sea" };

        var standardisedWordList = WordListStandardiser
            .Standardise(wordList)
            .ToArray();
        
        Assert.AreEqual(2, standardisedWordList.Length);
        Assert.AreEqual("land", standardisedWordList[0]);
        Assert.AreEqual("sea", standardisedWordList[1]);
    }

    [TestMethod]
    public void TestCanStandardise_DuplicateAndMixedCaseWords()
    {
        var wordList = new[] { "lANd", "sEa", "LanD", "SeA" };

        var standardisedWordList = WordListStandardiser
            .Standardise(wordList)
            .ToArray();
        
        Assert.AreEqual(2, standardisedWordList.Length);
        Assert.AreEqual("land", standardisedWordList[0]);
        Assert.AreEqual("sea", standardisedWordList[1]);
    }
}