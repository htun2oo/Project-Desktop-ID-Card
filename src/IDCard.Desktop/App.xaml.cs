using System;
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

            // Global Exception Catching (ဘာ Error တက်နေလဲ သိရရန်)
            this.DispatcherUnhandledException += (sender, args) =>
            {
                MessageBox.Show($"Startup Error: {args.Exception.Message}\n\n{args.Exception.StackTrace}", 
                    "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error);
                args.Handled = true;
                Shutdown();
            };

            try
            {
                // Database နှင့် Default Admin ကို အလိုအလျောက် ဖန်တီးခြင်း
                var dbService = new DatabaseService();
                dbService.EnsureDatabaseCreated();

                // Login Window ကို စတင်ပြသခြင်း
                var loginWindow = new LoginWindow();
                this.MainWindow = loginWindow;
                loginWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database or Window Init Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
