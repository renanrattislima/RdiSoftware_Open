namespace RdiSoftware.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
public class Amount2WordsController : ControllerBase
{

    private readonly ILogger<Amount2WordsController> _logger;

    public Amount2WordsController(ILogger<Amount2WordsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Converting numbers to extended values
    /// </summary>
    /// <param name="n">Integer value </param>
    /// <param name="m">Cents of the value</param>
    /// <remarks>Convert a decimal values into words (Portugues)</remarks>
    [HttpPost(Name = "convertAmount2Words")]
    public string Post(decimal n, decimal m)
    {
        try
        { 
            decimal number = n + (m / 100);
            string result = Conversor.WriteExtension(number);

            return result;
        }
        catch (Exception exception)
        {
            _logger.LogWarning("Message:", JsonSerializer.Serialize(exception?.Message));

            throw exception switch
            {
                ArgumentException => new ArgumentException(exception?.Message),
                FormatException => new FormatException(exception?.Message),
                ArithmeticException => new ArithmeticException(exception?.Message),
                _ => new Exception(exception?.Message)
            };
        }
    }
}