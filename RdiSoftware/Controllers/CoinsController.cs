namespace RdiSoftware.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
public class CoinsController : ControllerBase
{

    private readonly ILogger<CoinsController> _logger;

    public CoinsController(ILogger<CoinsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Find number of combinations coins > 1,5,10,20,25 to reach some value
    /// </summary>
    /// <param name="target">Value we want to know how much combinations exists</param>
    /// <remarks>Find the number of combinations of coins to reach the value of parameter</remarks>
    [HttpPost(Name = "convertCoins")]
    public long Post(int target)
    {
        try
        {
            var C = new int[] { 1, 5, 10, 20, 25, 50 };
            int m = C.Length;
            int n = target;

            return CoinsCombination.Count(C, m, n);
        }
        catch
        {
            return 0;
        }
    }
}