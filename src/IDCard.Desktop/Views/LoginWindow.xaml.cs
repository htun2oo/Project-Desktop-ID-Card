using System.Windows;
using System.Windows.Input;

namespace IDCard.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Password reset instructions have been sent to your administrator email.", 
                            "Forgot Password", 
                            MessageBoxButton.OK, 
                            MessageBoxImage.Information);
        }
    }
}
