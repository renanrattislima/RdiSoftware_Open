namespace UnitTest;

[TestClass]
public class PalindromeTestes
{

    private readonly PalindromeController _controller;
    private readonly ILogger<PalindromeController> _productPriceService;

    public PalindromeTestes()
    {
        _controller = new PalindromeController(_productPriceService);
    }

    [TestMethod]
    public void TestPalindrome()
    {
        string frase = "carroaco";

        var result = _controller.Post(frase);

        Assert.AreEqual("YES", result);

    }

    [TestMethod]
    public void TestPalindrome_2()
    {
        string frase = "abcabcabc";

        var result = _controller.Post(frase);

        Assert.AreEqual("NO", result);

    }
}