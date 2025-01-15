using Microsoft.AspNetCore.Mvc;
namespace RenderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RawController : ControllerBase
{
    [HttpGet("GetRawText")]
    public IActionResult GetRawText(string relativePath)
    {
        var filePath = relativePath;

        if (!System.IO.File.Exists(filePath)) return NotFound("Audio file not found");
        try
        {
            var fileContent = System.IO.File.ReadAllText(filePath);
            return Ok(fileContent);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid("You do not have permission to access this file.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}