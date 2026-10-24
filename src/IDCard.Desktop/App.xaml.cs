using System.Windows;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Login Window ကို ပထမဆုံး စတင်ဖော်ပြခြင်း
            LoginWindow loginWindow = new LoginWindow();
            
            // Login အောင်မြင်ပါက (DialogResult = true ဖြစ်ပါက) MainWindow ကို ဖွင့်မည်
            if (loginWindow.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow();
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
