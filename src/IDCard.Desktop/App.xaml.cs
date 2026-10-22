using System.Windows;
using IDCard.Desktop.Services;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Database နှင့် Default Admin အကောင့်ကို စတင်ဖန်တီးခြင်း
            DatabaseService.InitializeDatabase();
        }
    }
}
