using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.ViewModels;

namespace IDCard.Desktop.Views
{
    public partial class LoginWindow : ModernWpf.Controls.Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // PasswordBox ၏ စာသားပြောင်းလဲမှုကို ViewModel သို့ တိုက်ရိုက် ပို့ဆောင်ပေးခြင်း
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel && sender is System.Windows.Controls.PasswordBox passwordBox)
            {
                viewModel.Password = passwordBox.Password;
            }
        }

        // Forgot Password အတွက် Click Event Handler
        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Password recovery feature will be available soon.", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
