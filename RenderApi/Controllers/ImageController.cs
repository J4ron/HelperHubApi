using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RFE.Components.Pages;

namespace RenderApi.Controllers;

 [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _rootPath;

        public ImageController(IOptions<Settings> settings)
        {
            _rootPath = settings.Value.FolderPath;
        }

        [HttpGet("GetImage")]
        public IActionResult GetImage(string relativePath)
        {
            var filePath = Path.Combine(_rootPath, relativePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Image file not found");
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var mimeType = GetMimeType(filePath);

            return File(fileBytes, mimeType);
        }

        private string GetMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }
    }