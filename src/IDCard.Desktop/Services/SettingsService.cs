using System;
using System.IO;
using System.Text.Json;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public class SettingsService
    {
        private readonly string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDCardApp", "settings.json");

        public AppSettingsModel LoadSettings()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<AppSettingsModel>(json) ?? new AppSettingsModel();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading settings: {ex.Message}");
            }
            return new AppSettingsModel();
        }

        public void SaveSettings(AppSettingsModel settings)
        {
            try
            {
                string? dir = Path.GetDirectoryName(_filePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }
}
