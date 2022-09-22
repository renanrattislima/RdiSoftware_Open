namespace UnitTest;

[TestClass]
public class CoinsCombinationTestes
{
    private readonly CoinsController _controller;
    private readonly ILogger<CoinsController> _productPriceService;

    public CoinsCombinationTestes()
    {
        _controller = new CoinsController(_productPriceService);
    }

    [TestMethod]
    public void TestCoinsCombination()
    {
        int target = 10;

        var result = _controller.Post(target);

        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void TestCoinsCombination_2()
    {
        int target = 20;

        var result = _controller.Post(target);

        Assert.AreEqual(10, result);
    }
}