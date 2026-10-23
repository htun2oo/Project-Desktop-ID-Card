using System;
using System.IO;
using Microsoft.Data.Sqlite; // SQLite package ကို အသုံးပြုရန်

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        private static readonly string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDCardApp", "idcard.db");

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
            using var connection = new SqliteConnection(GetConnectionString());
            connection.Open();

            string commandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL
                );";

            using var command = new SqliteCommand(commandText, connection);
            command.ExecuteNonQuery();
        }
    }
}
