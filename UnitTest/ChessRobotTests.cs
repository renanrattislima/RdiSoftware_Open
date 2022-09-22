namespace UnitTest;

[TestClass]
public class ChessRobotTestes
{

    private readonly ChessRobotController _controller;
    private readonly ILogger<ChessRobotController> _productPriceService;

    public ChessRobotTestes()
    {
        _controller = new ChessRobotController(_productPriceService);
    }

    [TestMethod]
    public void TestChessRobot()
    {
        string frase = "RRRRDDDLLUUUUUUURRDDDDR";

        var result = _controller.Post(frase);

        Assert.AreEqual("Crossed", result);

    }

    [TestMethod]
    public void TestChessRobot_2()
    {
        string frase = "RRRRDDD";

        var result = _controller.Post(frase);

        Assert.AreEqual("Not Crossed", result);

    }
}