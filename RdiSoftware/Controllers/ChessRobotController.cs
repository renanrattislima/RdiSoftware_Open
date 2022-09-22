namespace RdiSoftware.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
public class ChessRobotController : ControllerBase
{
    private readonly ILogger<ChessRobotController> _logger;
    /*couldn't achieve the expectation but did something similar*/
    public ChessRobotController(ILogger<ChessRobotController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Validate path to check if movements are Crossed
    /// </summary>
    /// <param name="path">String of path with R = RIGHT | L = LEFT | U = UP | D = DOWN  </param>
    /// <remarks>Check if the given path is crossed</remarks>

    [HttpPost(Name = "convertChessRobot")]
    public string Post(string path)
    {
        try
        {
            return ChessRobot.IsCrossed(path);
        }
        catch (Exception exception)
        {
            _logger.LogWarning("Message:", JsonSerializer.Serialize(exception?.Message));

            throw exception switch
            {
                ArgumentException => new ArgumentException(exception?.Message),
                _ => new Exception(exception?.Message)
            };
        }
    }
}