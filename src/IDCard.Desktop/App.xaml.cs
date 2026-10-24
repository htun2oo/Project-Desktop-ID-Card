using System.Windows;
using IDCard.Desktop.Services;

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
        }
    }
}
