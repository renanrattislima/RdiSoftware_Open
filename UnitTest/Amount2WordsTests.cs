namespace UnitTest;

[TestClass]
public class Amount2WordsTestes
{
    private readonly Amount2WordsController _controller;
    private readonly ILogger<Amount2WordsController> _productPriceService;

    public Amount2WordsTestes()
    {
        _controller = new Amount2WordsController(_productPriceService);
    }

    [TestMethod]
    public void TestAmount2Words()
    {
        decimal value = 1000080;
        decimal cents = 0;

        var result = _controller.Post(value, cents);

        Assert.AreEqual("Um milhão e oitenta reais".ToUpper(), result);

    }

    [TestMethod]
    public void TestAmount2Words_2()
    {
        decimal value = 111;
        decimal cents = 11;

        var result = _controller.Post(value, cents);

        Assert.AreEqual("Cento e onze reais e onze centavos".ToUpper(), result);

    }
}