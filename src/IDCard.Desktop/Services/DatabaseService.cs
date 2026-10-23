using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public static class DatabaseService
    {
        public static void InitializeDatabase()
        {
            try
            {
                using var context = new AppDbContext();
                // Database နှင့် ဇယားများ မရှိသေးပါက အလိုအလျောက် ဖန်တီးပေးမည်
                context.Database.EnsureCreated();
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show($"Database Initialization Error: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
