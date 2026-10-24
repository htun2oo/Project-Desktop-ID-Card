using System.Windows;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Login Window ပိတ်သွားသော်လည်း App တစ်ခုလုံး မပိတ်သွားစေရန် ShutdownMode ကို ပြောင်းခြင်း
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            // Login Window ကို စတင်ဖော်ပြခြင်း
            LoginWindow loginWindow = new LoginWindow();
            
            // Login အောင်မြင်ပါက (DialogResult = true ဖြစ်ပါက) MainWindow ကို ဖွင့်မည်
            if (loginWindow.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow();
                
                // MainWindow သည် ပင်မ Window ဖြစ်လာစေရန် သတ်မှတ်ခြင်း
                this.MainWindow = mainWindow;
                
                // နောက်ဆုံး ပိတ်မည့် Window ကို MainWindow ဟု သတ်မှတ်ပေးခြင်းဖြင့် အလိုအလျောက် ပိတ်ခြင်းမှ ကာကွယ်မည်
                this.ShutdownMode = ShutdownMode.OnLastWindowClose;

                mainWindow.Show();
            }
            else
            {
                // Login မအောင်မြင်ပါက App ကို ရပ်တန့်မည်
                Shutdown();
            }
        }
    }
}
