using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        // AppData ထဲတွင် idcard.db ကို တိုက်ရိုက်သိမ်းဆည်းမည်
        public static string DbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDCardApp", "idcard.db");

        public static string GetConnectionString()
        {
            string? dir = Path.GetDirectoryName(DbPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return $"Data Source={DbPath}";
        }

        public static void InitializeDatabase()
        {
            try
            {
                using var connection = new SqliteConnection(GetConnectionString());
                connection.Open();

                // Users Table တည်ဆောက်ခြင်း
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );";

                using var command = new SqliteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();

                // Admin Account ထည့်သွင်းခြင်း (မရှိသေးပါက)
                string insertAdminQuery = @"
                    INSERT OR IGNORE INTO Users (Username, Password) 
                    VALUES ('admin', 'admin123');";

                using var insertCommand = new SqliteCommand(insertAdminQuery, connection);
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DB Init Error: {ex.Message}");
            }
        }
    }
}
