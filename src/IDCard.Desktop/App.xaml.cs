using System.Windows;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Database နှင့် Default Admin ကို အလိုအလျောက် ဖန်တီးခြင်း
            var dbService = new DatabaseService();
            dbService.EnsureDatabaseCreated();

            // Login Window ကို စတင်ပေါ်လာစေရန် ဖန်တီးပြီး ပြသခြင်း
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
