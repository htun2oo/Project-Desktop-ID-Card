using System.Windows;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. ပထမဆုံး Window ပိတ်သွားသော်လည်း App တစ်ခုလုံး မပိတ်သွားစေရန်
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // 2. Login Window ကို စတင်ဖွင့်လှစ်ခြင်း
            LoginWindow loginWindow = new LoginWindow();
            bool? dialogResult = loginWindow.ShowDialog();

            // 3. Login အောင်မြင်ပါက (DialogResult က true ဖြစ်ပါက)
            if (dialogResult == true)
            {
                MainWindow mainWindow = new MainWindow();
                
                // MainWindow ကို အဓိက App Window အဖြစ် သတ်မှတ်ပေးခြင်း
                this.MainWindow = mainWindow;
                
                // MainWindow ပိတ်မှသာ App လုံးဝ ပိတ်သွားစေရန် သတ်မှတ်ခြင်း
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
