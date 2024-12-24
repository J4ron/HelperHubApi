namespace RenderApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class AudioController : ControllerBase
{

    [HttpGet("GetAudio")]
    public IActionResult GetAudio(string relativePath)
    {
        var filePath = relativePath;

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound("Audio file not found");
        }

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "audio/mpeg");
    }
}

