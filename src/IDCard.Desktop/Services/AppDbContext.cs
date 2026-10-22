using Microsoft.EntityFrameworkCore;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite Database ဖိုင်သိမ်းဆည်းမည့် လမ်းကြောင်း
            optionsBuilder.UseSqlite("Data Source=idcard.db");
        }
    }
}
