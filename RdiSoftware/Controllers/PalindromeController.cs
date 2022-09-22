namespace RdiSoftware.Controllers;


[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
public class PalindromeController : ControllerBase
{

    private readonly ILogger<PalindromeController> _logger;

    public PalindromeController(ILogger<PalindromeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Validate Given String A Palindrome Permutation
    /// </summary>
    /// <param name="word">String to be validate </param>
    /// <remarks>Check if strophe has a permutation palindrome.</remarks>
    [HttpPost(Name = "convertPalindrome")]
    public string Post(string word)
    {
        try
        {
            var inputString = word;
            var characterSetMappingTable = PalindromePermutation.PrepareCharacterSetMappingTable(inputString);
            bool isOnlyOddOneFound = PalindromePermutation.IsOnlyOddOneFound(characterSetMappingTable);
            return isOnlyOddOneFound ? "YES" : "NO";

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