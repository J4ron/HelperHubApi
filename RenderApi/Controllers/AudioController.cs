using Microsoft.AspNetCore.Mvc;
namespace RenderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AudioController : ControllerBase
{
    private readonly FileMimeType _fileMimeType = new FileMimeType();

    [HttpGet("GetAudio")]
    public IActionResult GetAudio(string relativePath)
    {
        var filePath = relativePath;

        if (!System.IO.File.Exists(filePath)) return NotFound("Audio file not found");

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var mimeType = _fileMimeType.GetMimeType(filePath);

        return File(fileBytes, mimeType);
    }
}
