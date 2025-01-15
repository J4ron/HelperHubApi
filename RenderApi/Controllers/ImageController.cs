using Microsoft.AspNetCore.Mvc;
namespace RenderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly FileMimeType _fileMimeType = new FileMimeType();

    [HttpGet("GetImage")]
    public IActionResult GetImage(string relativePath)
    {
        var filePath = relativePath;

        if (!System.IO.File.Exists(filePath)) return NotFound("Image file not found");

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var mimeType = _fileMimeType.GetMimeType(filePath);

        return File(fileBytes, mimeType);
    }
}