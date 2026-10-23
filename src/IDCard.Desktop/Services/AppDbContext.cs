using Microsoft.EntityFrameworkCore;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // AppData ထဲတွင် idcard.db ကို တိကျစွာ ညွှန်ပြခြင်း
            string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "IDCardApp", "idcard.db");
            
            string? dir = System.IO.Path.GetDirectoryName(dbPath);
            if (!string.IsNullOrEmpty(dir) && !System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        public AppDbContext()
        {
            // Database နှင့် Users Table မရှိပါက EF Core က ချက်ချင်း အလိုအလျောက် ဆောက်ပေးမည်
            Database.EnsureCreated();
        }
    }
}
