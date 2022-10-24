using Kata08.repository.interfaces;
using Moq;

namespace Kata08.logic;

[TestClass]
public class FastAttemptTests
{
    private Mock<IWordListRepository>? _repoMock;
    private FastAttempt? _attempt;
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "con", "convex", "vex" });

        _attempt = new FastAttempt(_repoMock.Object);

        var wordsWithSubWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(1, wordsWithSubWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords_FullWordAboveMaxLength()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "be", "because", "cause" });

        _attempt = new FastAttempt(_repoMock.Object);

        var wordsWithSubWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(0, wordsWithSubWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords_OneOutlierWord()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "con", "convex", "vex", "zebra" });

        _attempt = new FastAttempt(_repoMock.Object);

        var wordsWithSubWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(1, wordsWithSubWords.Length);
    }
    
    [TestMethod]
    public async Task TestGetWordsWithSubWords_SubWordDoNotMakeWord()
    {
        _repoMock = new Mock<IWordListRepository>();
        _repoMock.Setup(x => x.GetWordList())
            .ReturnsAsync(new[] { "be", "because", "clause" });

        _attempt = new FastAttempt(_repoMock.Object);

        var wordsWithSubWords = (await _attempt.GetWordsWithSubWords()).ToArray();
        
        Assert.AreEqual(0, wordsWithSubWords.Length);
    }
}