using System.Linq;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        public static void InitializeDatabase()
        {
            using var context = new AppDbContext();
            context.Database.EnsureCreated();

            // အကယ်၍ Users ဇယားတွင် အကောင့်မရှိသေးပါက Default Admin အကောင့်ကို အလိုအလျောက် ထည့်သွင်းပေးမည်
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = "admin123" // လိုအပ်ပါက Password ကို ပြောင်းလဲနိုင်ပါသည်
                });
                context.SaveChanges();
            }
        }
    }
}
