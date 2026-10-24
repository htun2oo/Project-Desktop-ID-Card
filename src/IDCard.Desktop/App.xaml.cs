using System.Windows;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // App စတင်ဖွင့်လှစ်ချိန်တွင် Database နှင့် Default Tables များကို အလိုအလျောက် ဖန်တီးခြင်း
            DatabaseService.InitializeDatabase();

            // App တစ်ခုလုံး အလိုအလျောက် ပိတ်မသွားစေရန်
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            LoginWindow loginWindow = new LoginWindow();
            
            // ShowDialog() မှ true ပြန်လာမှသာ MainWindow ကို ဖွင့်မည်
            if (loginWindow.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow();
                this.MainWindow = mainWindow;
                
                // MainWindow ပိတ်မှသာ App လုံးဝ ပိတ်မည်
                this.ShutdownMode = ShutdownMode.OnLastWindowClose;

                mainWindow.Show();
            }
            else
            {
                Shutdown();
            }
        }
    }
}
