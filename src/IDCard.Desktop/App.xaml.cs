using System.Windows;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            LoginWindow loginWindow = new LoginWindow();
            
            if (loginWindow.ShowDialog() == true)
            {
                MainWindow mainWindow = new MainWindow();
                this.MainWindow = mainWindow;
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
