using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.ViewModels;

namespace IDCard.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        // Window ကို Mouse ဖြင့် ဖိ၍ရွှေ့ရန်
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // Window ပိတ်ရန်
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Sign In ခလုတ်နှိပ်သည့်အခါ PasswordBox မှ Password ကို ယူ၍ ViewModel သို့ ပေးပို့ရန်
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginViewModel viewModel)
            {
                // PasswordBox ထဲက password ကို ယူသည်
                viewModel.Password = PasswordBox.Password;

                // ယာယီစစ်ဆေးရန် Debug MessageBox (Password တန်ဖိုး ဝင်/မဝင် ကြည့်ရန်)
                MessageBox.Show($"PasswordBox Value: '{PasswordBox.Password}'\nViewModel Password: '{viewModel.Password}'", "Debug Check");

                if (viewModel.LoginCommand.CanExecute(null))
                {
                    viewModel.LoginCommand.Execute(null);
                }
            }
        }
    }
}
