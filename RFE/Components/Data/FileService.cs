namespace RFE.Components.Data;

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class FileService : IFileService
{
    public async Task<List<FileItem>> GetDirectoryContentsAsync(string directoryPath)
    {
        var items = new List<FileItem>();

        if (Directory.Exists(directoryPath))
        {
            // Ordner hinzufügen
            var directories = Directory.GetDirectories(directoryPath);
            items.AddRange(directories.Select(dir => new FileItem
            {
                Name = Path.GetFileName(dir),
                Path = dir,
                IsDirectory = true
            }));

            // Dateien hinzufügen
            var files = Directory.GetFiles(directoryPath);
            items.AddRange(files.Select(file => new FileItem
            {
                Name = Path.GetFileName(file),
                Path = file,
                IsDirectory = false
            }));
        }

        return items;
    }

    public async Task<string> ReadFileContentAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            return await File.ReadAllTextAsync(filePath);
        }

        return "File not found.";
    }
}
