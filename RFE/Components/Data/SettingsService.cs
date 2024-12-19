namespace RFE.Components.Data;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class SettingsService : ISettingsService
{
    private readonly string _settingsFilePath = "settings.json";

    public async Task SaveSettingsAsync(PathSettings pathSettings)
    {
        var json = JsonSerializer.Serialize(pathSettings, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_settingsFilePath, json);
    }

    public async Task<PathSettings> LoadSettingsAsync()
    {
        if (!File.Exists(_settingsFilePath))
        {
            return new PathSettings();
        }

        var json = await File.ReadAllTextAsync(_settingsFilePath);
        return JsonSerializer.Deserialize<PathSettings>(json) ?? new PathSettings();
    }
}
