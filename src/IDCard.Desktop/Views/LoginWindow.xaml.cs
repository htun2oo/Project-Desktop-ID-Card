using System.Windows;
using IDCard.Desktop.ViewModels;

namespace IDCard.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = PasswordBox.Password;
                viewModel.LoginCommand.Execute(null);
            }
        }
    }
}
