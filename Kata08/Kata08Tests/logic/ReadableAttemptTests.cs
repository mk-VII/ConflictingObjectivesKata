using Kata08.repository.interfaces;
using Moq;

namespace Kata08.logic;

[TestClass]
public class ReadableAttemptTests
{
    private Mock<IWordListRepository>? _repoMock;
    private ReadableAttempt? _attempt;
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "con", "convex", "vex" });

        _attempt = new ReadableAttempt(_repoMock.Object);

        var wordsMadeOfOtherWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(1, wordsMadeOfOtherWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords_FullWordAboveMaxLength()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "be", "because", "cause" });

        _attempt = new ReadableAttempt(_repoMock.Object);

        var wordsMadeOfOtherWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(0, wordsMadeOfOtherWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords_OneOutlierWord()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "con", "convex", "vex", "zebra" });

        _attempt = new ReadableAttempt(_repoMock.Object);

        var wordsMadeOfOtherWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(1, wordsMadeOfOtherWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsMadeOfOtherWords_SubWordDoNotMakeWord()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "be", "because", "clause" });

        _attempt = new ReadableAttempt(_repoMock.Object);

        var wordsMadeOfOtherWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(0, wordsMadeOfOtherWords.Length);
    }
}