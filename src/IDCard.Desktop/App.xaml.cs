using System;
using System.Windows;
using System.Windows.Threading;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // MainWindow ပိတ်မှသာ အပလီကေးရှင်း ပိတ်မည်
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;

            // Database စတင်ချိတ်ဆက်ခြင်း
            DatabaseService.InitializeDatabase();

            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // LoginWindow ကို ပထမဆုံး စတင်ဖွင့်လှစ်ခြင်း
            var loginWindow = new LoginWindow();
            
            // LoginWindow ကို Application ၏ Main Window အဖြစ် ဦးစွာသတ်မှတ်ပါ
            this.MainWindow = loginWindow;
            
            loginWindow.Show();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}", "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                MessageBox.Show($"A critical error occurred: {ex.Message}", "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
