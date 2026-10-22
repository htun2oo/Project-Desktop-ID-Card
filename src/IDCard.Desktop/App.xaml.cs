using System.Windows;
using IDCard.Desktop.Services;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // အပလီကေးရှင်း စတင်သည်နှင့် Database နှင့် Table များကို ဖန်တီးရန်
            DatabaseService.InitializeDatabase();
        }
    }
}
