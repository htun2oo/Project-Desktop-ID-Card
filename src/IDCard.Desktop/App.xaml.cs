using System.Windows;
using System.Windows.Threading;
using IDCard.Desktop.Services;

namespace IDCard.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // မမျှော်လင့်ထားသော Error များကို ဖမ်းယူရန်
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            // Database Initialize ပြုလုပ်ခြင်း
            try
            {
                DatabaseService.InitializeDatabase();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Database Init Error: {ex.Message}", "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Runtime Error: {e.Exception.Message}\n\nStack Trace: {e.Exception.StackTrace}", "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
