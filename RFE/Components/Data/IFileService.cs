namespace RFE.Components.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFileService
{
    Task<List<FileItem>> GetDirectoryContentsAsync(string directoryPath);
    Task<string> ReadFileContentAsync(string filePath);
}
