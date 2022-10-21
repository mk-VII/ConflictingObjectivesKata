namespace Kata08.model;

[TestClass]
public class WordWithSubWordsTests
{
    [TestMethod]
    public void TestCanConstruct_AndOutputAsString()
    {
        var constructed = new WordWithSubWords("because", "be", "cause");

        var outputString = constructed.ToString();
        
        Assert.AreEqual("be + cause => because", outputString);
    }
}