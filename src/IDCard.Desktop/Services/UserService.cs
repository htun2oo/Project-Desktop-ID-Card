using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using IDCard.Desktop.Models; // Model ကို အသုံးပြုရန် မဖြစ်မနေ ထည့်ရန်

namespace IDCard.Desktop.Services
{
    public static class UserService
    {
        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDCardApp", "users.json");

        public static List<User> LoadUsers()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<List<User>>(json) ?? GetDefaultUsers();
                }
            }
            catch { }
            
            return GetDefaultUsers();
        }

        private static List<User> GetDefaultUsers()
        {
            var defaultUsers = new List<User>
            {
                new User { Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Username = "user1", Password = "123", Role = "User" }
            };
            SaveUsers(defaultUsers);
            return defaultUsers;
        }

        public static void SaveUsers(List<User> users)
        {
            try
            {
                string? dir = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch { }
        }

        public static User? Authenticate(string username, string password)
        {
            var users = LoadUsers();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }
    }
}
