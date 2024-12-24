using Microsoft.Extensions.Options;
using RFE.Components.Pages;

namespace RenderApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Options;

    [Route("api/[controller]")]
    [ApiController]
    public class RawController : ControllerBase
    {
        private readonly string _rootPath;

        public RawController(IOptions<Settings> settings)
        {
            _rootPath = settings.Value.FolderPath;
        }

        [HttpGet("GetRawText")]
        public IActionResult GetRawText(string relativePath)
        {
            var filePath = Path.Combine(_rootPath, relativePath);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

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

