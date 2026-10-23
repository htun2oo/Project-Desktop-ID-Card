using Microsoft.EntityFrameworkCore;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Local SQLite database ဖိုင် ဖန်တီးမည့် လမ်းကြောင်း
            optionsBuilder.UseSqlite("Data Source=idcard_system.db");
        }
    }
}
