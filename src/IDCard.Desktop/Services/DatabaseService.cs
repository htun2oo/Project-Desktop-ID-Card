using System.Linq;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public class DatabaseService
    {
        public DatabaseService()
        {
            EnsureDatabaseCreated();
        }

        public void EnsureDatabaseCreated()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                // Default Admin Account ကို အလိုအလျောက် ထည့်သွင်းပေးခြင်း (Seeding)
                if (!context.Users.Any(u => u.Username == "admin"))
                {
                    context.Users.Add(new User
                    {
                        Username = "admin",
                        Password = "admin123",
                        Role = "Administrator"
                    });
                    context.SaveChanges();
                }
            }
        }

        public bool ValidateUser(string username, string password)
        {
            using (var context = new AppDbContext())
            {
                // Username နှင့် Password တိုက်ဆိုင်မှု ရှိမရှိ စစ်ဆေးခြင်း
                return context.Users.Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}
