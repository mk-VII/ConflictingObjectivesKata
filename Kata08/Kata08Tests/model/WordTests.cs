namespace Kata08.model;

[TestClass]
public class WordTests
{
    [TestMethod]
    public void TestCanCreateFromSubWords_AndOutputAsString()
    {
        var constructed = new Word( new[] {"be", "cause"});
        
        var components = constructed.SubComponents.ToArray();
        Assert.AreEqual(2, components.Length);
        Assert.AreEqual("be", components[0]);
        Assert.AreEqual("cause", components[1]);
        
        var outputString = constructed.ToString();
        Assert.AreEqual("be + cause => because", outputString);
    }
    
    [TestMethod]
    public void TestCanCreateFromSubWords_EmptyComponentsArray()
    {
        var constructed = new Word(Array.Empty<string>());
        
        var components = constructed.SubComponents.ToArray();
        Assert.AreEqual(0, components.Length);
        
        var outputString = constructed.ToString();
        Assert.AreEqual(string.Empty, outputString);
    }
}