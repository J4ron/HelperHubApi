namespace RFE.Components.Data;
using System.Threading.Tasks;

public interface ISettingsService
{
    Task SaveSettingsAsync(PathSettings pathSettings);
    Task<PathSettings> LoadSettingsAsync();
}
