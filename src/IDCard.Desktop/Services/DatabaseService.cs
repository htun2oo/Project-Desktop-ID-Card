using System;
using System.IO;
using System.Linq;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        public static string DbPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "IDCardApp", "idcard.db");

        public static void InitializeDatabase()
        {
            try
            {
                using var context = new AppDbContext();
                
                // EF Core ဖြင့် Database နှင့် Table များ ဖန်တီးခြင်း
                context.Database.EnsureCreated();

                // Admin Account မရှိသေးပါက အလိုအလျောက် ထည့်သွင်းခြင်း
                var adminUser = context.Users.FirstOrDefault(u => u.Username == "admin");
                if (adminUser == null)
                {
                    context.Users.Add(new User
                    {
                        Username = "admin",
                        Password = "admin123",
                        Role = "Admin"
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DB Init Error: {ex.Message}");
            }
        }
    }
}
