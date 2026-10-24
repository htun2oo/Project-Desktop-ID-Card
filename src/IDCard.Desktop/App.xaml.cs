using System.Windows;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // App တစ်ခုလုံး ပုံမှန် အလုပ်လုပ်နေစေရန် Explicit Shutdown သို့ သတ်မှတ်ခြင်း
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // Login Window ကို စတင်ဖော်ပြခြင်း
            LoginWindow loginWindow = new LoginWindow();
            
            // ShowDialog() အစား Show() ကို သုံး၍ DialogResult အပေါ် မူမတည်ဘဲ ထိန်းချုပ်ခြင်း
            bool? result = loginWindow.ShowDialog();

            if (result == true)
            {
                // Login အောင်မြင်ပါက MainWindow ကို အဓိက Window အဖြစ် သတ်မှတ်ဖွင့်လှစ်မည်
                MainWindow mainWindow = new MainWindow();
                this.MainWindow = mainWindow;
                
                // နောက်ဆုံး Window ပိတ်လျှင် App ပိတ်စေရန် သတ်မှတ်ခြင်း
                this.ShutdownMode = ShutdownMode.OnLastWindowClose;

                mainWindow.Show();
            }
            else
            {
                // Login မအောင်မြင်ပါက သို့မဟုတ် ပိတ်လိုက်ပါက App ကို ရပ်တန့်မည်
                Shutdown();
            }
        }
    }
}
