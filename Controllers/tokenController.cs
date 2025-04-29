using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/token")]
public class TokenController : ControllerBase
{
    private readonly LiveKitTokenService _tokenService = new LiveKitTokenService();

    [HttpGet]
public IActionResult GetToken([FromQuery] string identity, [FromQuery] string room, [FromQuery] bool isHost)
{
    try
    {
        var token = _tokenService.GenerateToken(identity, room, isHost);
        return Ok(new { token });
    }
    catch (Exception ex)
    {
        // Log the error for backend debug
        Console.WriteLine("Token generation error: " + ex.Message);
        return StatusCode(500, new { error = ex.Message }); // ✅ Return structured JSON error
    }
}

   
}
