using IDCard.Desktop.Models;
using System.Linq;

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        public static void InitializeDatabase()
        {
            try
            {
                using var context = new AppDbContext();
                context.Database.EnsureCreated();

                // Admin အကောင့် ရှိမရှိ စစ်ဆေးပြီး မရှိပါက အလိုအလျောက် ထည့်သွင်းပေးရန်
                if (!context.Users.Any(u => u.Username == "admin"))
                {
                    context.Users.Add(new User
                    {
                        Username = "admin",
                        PasswordHash = "admin123" // လိုအပ်ပါက Hash လုပ်၍ သို့မဟုတ် တိုက်ရိုက်ထည့်နိုင်သည်
                    });
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Database Error: {ex.Message}");
            }
        }
    }
}
