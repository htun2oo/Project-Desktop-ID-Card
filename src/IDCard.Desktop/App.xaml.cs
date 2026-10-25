using System.Windows;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views; // LoginWindow တည်ရှိရာ Views namespace ကို ချိတ်ရန်

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Database နှင့် Default Admin ကို အလိုအလျောက် ဖန်တီးခြင်း
            var dbService = new DatabaseService();
            dbService.EnsureDatabaseCreated();

            // Login Window ကို စတင်ဖွင့်လှစ်ခြင်း
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
